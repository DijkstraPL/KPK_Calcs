import { Component, Input, SimpleChanges, Output, EventEmitter, SimpleChange } from '@angular/core';
import { Parameter } from '../../../models/interfaces/parameter';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ParameterOptions } from '../../../models/enums/parameterOptions';
import { ValueOption } from '../../../models/interfaces/valueOption';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';
import { ParameterFilter } from '../../../models/enums/parameter-filter';
import { validateConfig } from '@angular/router/src/config';
import { ValueOptionSettings } from '../../../models/enums/valueOptionSettings';

@Component({
    selector: 'app-data-parameters-form',
    templateUrl: './data-parameters-form.component.html',
    styleUrls: ['./data-parameters-form.component.css']
})

export class DataParametersFormComponent {
    @Input('editMode') editMode: boolean;
    @Input('scriptId') scriptId: number;
    @Input('newParameter') newParameter: Parameter = new ParameterImpl();

    @Output('created') created = new EventEmitter<Parameter>();

    type: string = ParameterFilter[ParameterFilter.data];
    allowUserValues = false;

    constructor(private parameterService: ParameterService) {
    }
    
    ngOnChanges(changes: SimpleChanges) {

        if (changes.newParameter) 
            this.setNewParameterChanges(changes.newParameter);

        if (changes.editMode)
            this.editMode = changes.editMode.currentValue;
    }
    
    addValueOption() {
        let valueOption = new ValueOptionImpl();
        if (this.newParameter.valueOptions.length > 0)
            valueOption.id = Math.max.apply(Math, this.newParameter.valueOptions.map(function (vo) { return vo.id })) + 1;
        else
            valueOption.id = 0;
        this.newParameter.valueOptions.push(valueOption);
    }

    removeValueOption(valueOption: ValueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(vo => vo !== valueOption);

        if (this.newParameter.valueOptions.length == 0) 
            this.newParameter.valueOptionSetting = ValueOptionSettings.None;
    }

    onAllowUserValues() {
        this.newParameter.valueOptionSetting =
            this.allowUserValues ? ValueOptionSettings.UserInput : ValueOptionSettings.None;
        alert(this.newParameter.valueOptionSetting);
    }

    onSubmit($event) {
        this.adjustProperties();
        this.setContext();

        if (!this.editMode)
            this.create();
        else
            this.update();
    }

    private setNewParameterChanges(newParameter: SimpleChange) {
        console.log('Previous parameter: ', newParameter.previousValue);
        console.log('New parameter: ', newParameter.currentValue);
        this.newParameter = newParameter.currentValue;
        this.setDataType();
        this.setValueOptionsSettings();
    }

    private setDataType() {
        if ((this.newParameter.context & ParameterFilter.data) != 0)
            this.type = ParameterFilter[ParameterFilter.data];
        else if ((this.newParameter.context & ParameterFilter.static) != 0)
            this.type = ParameterFilter[ParameterFilter.static];
        else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
            this.type = ParameterFilter[ParameterFilter.calculation];
    }

    private setValueOptionsSettings() {
        this.allowUserValues = this.newParameter.valueOptionSetting == ValueOptionSettings.UserInput;
    }

    private adjustProperties() {
        if (this.type === ParameterFilter[ParameterFilter.static]) {
            this.newParameter.dataValidator = null;
            this.newParameter.valueOptions = null;
        }
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.newParameter.valueOptions = null;
    }

    private setContext() {
        if (this.type === ParameterFilter[ParameterFilter.data])
            this.newParameter.context = ParameterOptions.Editable | ParameterOptions.Visible;
        else if (this.type === ParameterFilter[ParameterFilter.static])
            this.newParameter.context = ParameterOptions.StaticData;
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.newParameter.context = ParameterOptions.Calculation | ParameterOptions.Visible;
    }

    private create() {
        this.created.emit(this.newParameter);
    }

    private update() {
        this.parameterService.update(this.scriptId, this.newParameter)
            .subscribe((p: Parameter) => {
                console.log(p);
            },
                error => console.error(error));
    }
}