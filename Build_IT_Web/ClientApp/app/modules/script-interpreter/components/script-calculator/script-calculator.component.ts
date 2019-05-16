import { Component, OnInit } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/interfaces/script';
import { Parameter } from '../../models/interfaces/parameter';
import { ParameterOptions } from '../../models/enums/parameterOptions';
import { ActivatedRoute } from '@angular/router';
import { ParameterService } from '../../services/parameter.service';
import { CalculationService } from '../../services/calculation.service';
import { ValueType } from '../../models/enums/valueType';
import { isNullOrUndefined, log } from 'util';
import { ValueOption } from '../../models/interfaces/valueOption';
import { ValueOptionSettings } from '../../models/enums/valueOptionSettings';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'app-script-calculator',
    templateUrl: './script-calculator.component.html',
    styleUrls: ['./script-calculator.component.less']
})

export class ScriptCalculatorComponent implements OnInit {
    myControl = new FormControl();

    script: Script;
    parameters: Parameter[];
    visibleParameters: Parameter[];
    resultParameters: Parameter[];

    valueChanged: boolean;
    parameterOptions = ParameterOptions;
    valueOptionSetting = ValueOptionSettings;

    displayedColumns: string[] = ['name', 'value', 'unit', 'description'];

    constructor(
        private route: ActivatedRoute,
        private scriptService: ScriptService,
        private parameterService: ParameterService,
        private calculationService: CalculationService) {
    }

    ngOnInit(): void {
        let id;
        let sub = this.route.params.subscribe(params => {
            id = +params['id'];
        });
        if (id != undefined) {
            this.scriptService.getScript(id).subscribe(script => {
                this.script = script;
                console.log("Script", this.script);
                this.setParameters();
            }, error => console.error(error));
        }
        sub.unsubscribe();
    }

    private setParameters(): void {
        this.parameterService.getParameters(this.script.id).subscribe(parameters => {
            this.parameters = parameters.filter(p => (p.context & ParameterOptions.Editable) != 0),
                this.parameters.forEach(p => this.prepareParameter(p)),
                this.filterParameters(),
                console.log("Parameters", this.parameters);
        }, error => console.error(error));
    }

    private prepareParameter(parameter: Parameter): void {
        parameter.equation = parameter.value;
    }

    sortParameters(parameters: Parameter[], prop: string) {
        if (parameters)
            return parameters.sort(
                (a, b) => a[prop] > b[prop] ? 1 :
                    a[prop] === b[prop] ? 0 :
                        -1);
    }

    setValueChanged(parameter: Parameter) {
        this.valueChanged = true;

        this.filterParameters();
    }

    isImportant(parameter: Parameter): boolean {
        return (parameter.context & ParameterOptions.Important) != 0
    }
    
    filterParameters() {
        this.visibleParameters = this.parameters.filter(p => (p.context & ParameterOptions.Visible) != 0 && this.validateVisibility(p));
    }
    
    calculate() {
        this.calculationService.calculate(this.script.id, this.parameters)
            .subscribe(params => {
                this.resultParameters = params.filter(p => (p.context & ParameterOptions.Visible) != 0);
                console.log("Results", this.resultParameters);
            }, error => console.error(error));
               
        this.valueChanged = false;
    }

    private validateVisibility(parameter: Parameter): boolean {
        if (!parameter.visibilityValidator)
            return true;
               
        let visibilityValidatorEquation = parameter.visibilityValidator.slice(
            parameter.visibilityValidator.indexOf('(') + 1,
            parameter.visibilityValidator.lastIndexOf(')'));

        this.parameters.forEach(p => {
            let value = p.valueType == ValueType.number ? p.value : `'${p.value}'`;
            visibilityValidatorEquation = visibilityValidatorEquation.replace(`[${p.name}]`, value)
        });

        try {
            let result = eval(visibilityValidatorEquation) as boolean;
            if (result != null && !result && parameter.value != parameter.equation)
                parameter.value = parameter.equation;
            if (result != null)
                return result;
            else
                return true;
        } catch (e) {
            return true;
        }
    }
}