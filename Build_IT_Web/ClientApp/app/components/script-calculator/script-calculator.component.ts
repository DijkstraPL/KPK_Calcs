import { Component, OnInit } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/script';
import { Parameter } from '../../models/parameter';
import { ParameterOptions } from '../../models/parameterOptions';

@Component({
    selector: 'app-script-calculator',
    templateUrl: './script-calculator.component.html',
    styleUrls: ['./script-calculator.component.css']
})

export class ScriptCalculatorComponent implements OnInit {

    scripts: Script[] = [];
    selectedScript: Script;
    parameters: Parameter[];
    parameterOptions = ParameterOptions;
    resultParameters: Parameter[];

    valueChanged: boolean;

    constructor(private scriptService: ScriptService) {

    }

    ngOnInit(): void {
        this.setScript();
    }

    private setScript(): void {
        this.scriptService.getScripts().subscribe(scripts => {
            this.scripts = scripts;
            console.log("Scripts", this.scripts);
        }, error => console.error(error));
    }

    onChange() {
        this.setParameters();
    }

    private setParameters(): void {
        this.scriptService.getParameters(this.selectedScript.id).subscribe(parameters => {
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

        this.scriptService.calculate(this.selectedScript.name, parameters)
            .subscribe(params => {
                this.resultParameters = params;
                console.log("Results", this.resultParameters);
            }, error => console.error(error));

        this.valueChanged = false;
    }
}