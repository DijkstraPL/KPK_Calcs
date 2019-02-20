import { Component, OnInit } from '@angular/core';
import { Parameter } from '../../models/parameter';
import { ScriptService } from '../../services/script.service';
import { ActivatedRoute } from '@angular/router';
import { ParameterImpl } from '../../models/parameterImpl';
import { ParameterService } from '../../services/parameter.service';
import { ParameterOptions } from '../../models/parameterOptions';
import { ValueOptionImpl } from '../../models/valueOptionImpl';
import { ValueOption } from '../../models/valueOption';

@Component({
    selector: 'app-parameters-form',
    templateUrl: './parameters-form.component.html',
    styleUrls: ['./parameters-form.component.css']
})
/** parameters-form component*/
export class ParametersFormComponent implements OnInit {
    dataParameters: Parameter[];
    staticParameters: Parameter[];
    calculationParameters: Parameter[];

    scriptId: number;

    dataParameter: Parameter = new ParameterImpl();
    staticParameter: Parameter = new ParameterImpl();
    calculationParameter: Parameter = new ParameterImpl();
    editMode: boolean = false;

    constructor(private parameterService: ParameterService,
                private route: ActivatedRoute) {
    }
    
    ngOnInit() {
        this.route.params.subscribe(params => {
            this.scriptId = +params['id'];
        });

        if (isNaN(this.scriptId)) {
            return;
        }

        this.getParameters(this.scriptId);
    }
    
    getParameters(id: number) {
        this.parameterService.getParameters(id).subscribe(parameters => {
            this.dataParameters = parameters.filter(p => (p.context & 2) != 0);
            this.staticParameters = parameters.filter(p => (p.context & 8) != 0);
            this.calculationParameters = parameters.filter(p => (p.context & 4) != 0),
                console.log("Data parameters", this.dataParameters);
            console.log("Static parameters", this.staticParameters);
            console.log("Calculation parameters", this.calculationParameters);
        }, error => console.error(error));
    }

    onSubmitDataParameter() {
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

    onSubmitStaticDataParameter() {
        let maxNumber = Math.max.apply(Math, this.staticParameters.map(function (dp) { return dp.number; }))
        if (maxNumber < 800)
            maxNumber = 800;
        this.staticParameter.number = ++maxNumber;
        this.staticParameter.context = ParameterOptions.StaticData;

        this.parameterService.create(this.scriptId, this.staticParameter)
            .subscribe((p: Parameter) => {
                console.log(p);
                this.staticParameters.push(p);
            });
    }

    onSubmitCalculationParameter() {
        let maxNumber = Math.max.apply(Math, this.calculationParameters.map(function (dp) { return dp.number; }))
        if (maxNumber < 1000)
            maxNumber = 1000;
        this.calculationParameter.number = ++maxNumber;
        this.calculationParameter.context = ParameterOptions.Calculation | ParameterOptions.Visible;

        this.parameterService.create(this.scriptId, this.calculationParameter)
            .subscribe((p: Parameter) => {
                console.log(p);
                this.calculationParameters.push(p);
            },
            error => console.error(error));
    }

    edit(parameter: Parameter) {
        this.parameterService.update(this.scriptId, parameter)
            .subscribe((p: Parameter) => {
                console.log(p);
            },
                error => console.error(error));
    }

    remove(parameterId: number) {
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe((p: Parameter) =>
            {
                console.log("Parameters", p),
                this.dataParameters = this.dataParameters.filter(p => p.id != parameterId),
                this.staticParameters = this.staticParameters.filter(p => p.id != parameterId),
                this.calculationParameters = this.calculationParameters.filter(p => p.id != parameterId)
            }, error => console.error(error));
    }

    editDataParameter(parameter: Parameter) {
        this.editMode = true;
        this.dataParameter = parameter;
    }
    editStaticParameter(parameter: Parameter) {
        this.editMode = true;
        this.staticParameter = parameter;
    }
    editCalculationParameter(parameter: Parameter) {
        this.editMode = true;
        this.calculationParameter = parameter;
    }

    addValueOption() {
        this.dataParameter.valueOptions.push(new ValueOptionImpl());
    }

    removeValueOption(valueOption: ValueOption) {
        this.dataParameter.valueOptions =
            this.dataParameter.valueOptions
                .filter(vo => vo !== valueOption);
    }
}