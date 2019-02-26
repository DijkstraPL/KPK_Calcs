import { Component, Input, SimpleChanges, SimpleChange } from '@angular/core';
import { Parameter } from '../../../models/parameter';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ParameterOptions } from '../../../models/parameterOptions';
import { ValueOption } from '../../../models/valueOption';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';
import { ParameterFilter } from '../../../models/enums/parameter-filter';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-data-parameters-form',
    templateUrl: './data-parameters-form.component.html',
    styleUrls: ['./data-parameters-form.component.css']
})

export class DataParametersFormComponent {
    @Input() editMode: boolean;
    @Input() scriptId: number;
    @Input() newParameter: Parameter = new ParameterImpl();

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

    setDataType() {
        if ((this.newParameter.context & ParameterFilter.data) != 0)
            this.type = ParameterFilter[ParameterFilter.data];
        else if ((this.newParameter.context & ParameterFilter.static) != 0)
            this.type = ParameterFilter[ParameterFilter.static];
        else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
            this.type = ParameterFilter[ParameterFilter.calculation];
    }

    setContext() {
        if (this.type === ParameterFilter[ParameterFilter.data])
            this.newParameter.context = ParameterOptions.Editable | ParameterOptions.Visible;
        else if (this.type === ParameterFilter[ParameterFilter.static])
            this.newParameter.context = ParameterOptions.StaticData;
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.newParameter.context = ParameterOptions.Calculation | ParameterOptions.Visible;
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

        if (!this.editMode)
            this.create();
        else
            this.update();
    }

    private adjustProperties() {
        if (this.type === ParameterFilter[ParameterFilter.static])
            this.newParameter.dataValidator = null;
    }

    private create() {
        //if ((this.newParameter.context & ParameterFilter.data) != 0)
        //    this.newParameter.number = this.parameters.filter(p => (p.context & ParameterFilter.data) != 0).length;

        //this.parameterService.create(this.scriptId, this.newParameter)
        //    .subscribe((p: Parameter) => {
        //        console.log(p);
        //        this.parameters.push(p);
        //    });
    }

    private update() {
        this.setContext();

        this.parameterService.update(this.scriptId, this.newParameter)
            .subscribe((p: Parameter) => {
                console.log(p);
            },
                error => console.error(error));
    }
}