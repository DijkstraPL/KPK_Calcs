import { Component, OnInit } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/script';
import { Parameter } from '../../models/parameter';
import { ParameterOptions } from '../../models/parameterOptions';
import { ActivatedRoute } from '@angular/router';

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

    constructor(private route: ActivatedRoute, private scriptService: ScriptService) {
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
        this.scriptService.getEditableParameters(this.script.id).subscribe(parameters => {
            this.parameters = parameters;
            console.log("Parameters", this.parameters);
        }, error => console.error(error));
    }

    setValueChanged() {
        this.valueChanged = true;
    }

    calculate() {
        let parameters: string = "";
        this.parameters.filter(parameter => (parameter.context & ParameterOptions.Editable) != 0)
            .forEach(parameter => {
                parameters += "[";
                parameters += parameter.name;
                parameters += "]=";
                parameters += parameter.value;
                parameters += "|";
            });
        parameters = parameters.substr(0, parameters.length - 1);

        this.scriptService.calculate(this.script.name, parameters)
            .subscribe(params => {
                this.resultParameters = params;
                console.log("Results", this.resultParameters);
            }, error => console.error(error));

        this.valueChanged = false;
    }
}