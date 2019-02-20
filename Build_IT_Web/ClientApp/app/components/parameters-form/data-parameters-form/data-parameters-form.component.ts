import { Component } from '@angular/core';
import { Parameter } from '../../../models/parameter';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ParameterOptions } from '../../../models/parameterOptions';
import { ValueOption } from '../../../models/valueOption';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';

@Component({
    selector: 'app-data-parameters-form',
    templateUrl: './data-parameters-form.component.html',
    styleUrls: ['./data-parameters-form.component.css']
})

export class DataParametersFormComponent {
    dataParameters: Parameter[];
    dataParameter: Parameter = new ParameterImpl();
    editMode: boolean;
    scriptId: number;

    constructor(private parameterService: ParameterService) {

    }

    private getParameters(id: number) {
        this.parameterService.getParameters(id).subscribe(parameters => {
            this.dataParameters = parameters.filter(p => (p.context & 2) != 0);
                console.log("Data parameters", this.dataParameters);
        }, error => console.error(error));
    }

    private onSubmitDataParameter() {
        let maxNumber = Math.max.apply(Math, this.dataParameters.map(function (dp) { return dp.number; }))
        if (maxNumber < 0)
            maxNumber = 0;
        this.dataParameter.number = ++maxNumber;
        this.dataParameter.context = ParameterOptions.Editable | ParameterOptions.Visible;

        this.parameterService.create(this.scriptId, this.dataParameter)
            .subscribe((p: Parameter) => {
                console.log(p);
                this.dataParameters.push(p);
            });
    }

    private remove(parameterId: number) {
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe((p: Parameter) => {
                console.log("Parameters", p),
                    this.dataParameters = this.dataParameters.filter(p => p.id != parameterId)
            }, error => console.error(error));
    }

    private editDataParameter(parameter: Parameter) {
        this.editMode = true;
        this.dataParameter = parameter;
    }

    private addValueOption() {
        this.dataParameter.valueOptions.push(new ValueOptionImpl());
    }

    private removeValueOption(valueOption: ValueOption) {
        this.dataParameter.valueOptions =
            this.dataParameter.valueOptions
                .filter(vo => vo !== valueOption);
    }
}