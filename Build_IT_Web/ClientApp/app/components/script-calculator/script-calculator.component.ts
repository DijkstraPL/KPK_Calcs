import { Component, OnInit } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/interfaces/script';
import { Parameter } from '../../models/interfaces/parameter';
import { ParameterOptions } from '../../models/enums/parameterOptions';
import { ActivatedRoute } from '@angular/router';
import { ParameterService } from '../../services/parameter.service';
import { CalculationService } from '../../services/calculation.service';

@Component({
    selector: 'app-script-calculator',
    templateUrl: './script-calculator.component.html',
    styleUrls: ['./script-calculator.component.css']
})

export class ScriptCalculatorComponent implements OnInit {

    script: Script;
    parameters: Parameter[];
    parameterOptions = ParameterOptions;
    resultParameters: Parameter[];

    valueChanged: boolean;

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
            console.log("Parameters", this.parameters);
        }, error => console.error(error));
    }

    sortParameters(parameters: Parameter[], prop: string) {
        if (parameters)
            return parameters.sort(
                (a, b) => a[prop] > b[prop] ? 1 :
                    a[prop] === b[prop] ? 0 :
                        -1);
    }

    setValueChanged() {
        this.valueChanged = true;
    }

    calculate() {
        this.calculationService.calculate(this.script.id, this.parameters)
            .subscribe(params => {
                this.resultParameters = params;
                console.log("Results", this.resultParameters);
            }, error => console.error(error));

        this.valueChanged = false;
    }
}