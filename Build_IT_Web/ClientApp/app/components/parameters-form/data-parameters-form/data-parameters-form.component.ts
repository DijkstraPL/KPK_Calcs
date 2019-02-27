import { Component, Input, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { Parameter } from '../../../models/interfaces/parameter';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ParameterOptions } from '../../../models/enums/parameterOptions';
import { ValueOption } from '../../../models/interfaces/valueOption';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';
import { ParameterFilter } from '../../../models/enums/parameter-filter';

@Component({
    selector: 'app-data-parameters-form',
    templateUrl: './data-parameters-form.component.html',
    styleUrls: ['./data-parameters-form.component.css']
})

export class DataParametersFormComponent {
    @Input() editMode: boolean;
    @Input() scriptId: number;
    @Input() newParameter: Parameter = new ParameterImpl();

    @Output() created = new EventEmitter<Parameter>();

    type: string = ParameterFilter[ParameterFilter.data];

    constructor(private parameterService: ParameterService) {
    }

    ngOnChanges(changes: SimpleChanges) {

        if (changes.newParameter) {
            const newParameter = changes.newParameter;
            console.log('Previous parameter: ', newParameter.previousValue);
            console.log('New parameter: ', newParameter.currentValue);
            this.newParameter = newParameter.currentValue;

            this.setDataType();
        }

        if (changes.editMode)
            this.editMode = changes.editMode.currentValue;
    }
    
    addValueOption() {
        this.newParameter.valueOptions.push(new ValueOptionImpl());
    }

    removeValueOption(valueOption: ValueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(vo => vo !== valueOption);
    }

    onSubmit() {
        this.adjustProperties();
        this.setContext();

        if (!this.editMode)
            this.create();
        else
            this.update();
    }

    private setDataType() {
        if ((this.newParameter.context & ParameterFilter.data) != 0)
            this.type = ParameterFilter[ParameterFilter.data];
        else if ((this.newParameter.context & ParameterFilter.static) != 0)
            this.type = ParameterFilter[ParameterFilter.static];
        else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
            this.type = ParameterFilter[ParameterFilter.calculation];
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