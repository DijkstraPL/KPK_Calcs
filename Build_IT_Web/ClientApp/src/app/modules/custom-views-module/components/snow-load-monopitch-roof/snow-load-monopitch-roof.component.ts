import { Component, OnInit, Directive, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ScriptService } from '../../../script-interpreter/services/script.service';
import { ParameterService } from '../../../script-interpreter/services/parameter.service';
import { CalculationService } from '../../../script-interpreter/services/calculation.service';
import { TranslationService } from '../../../../services/translation.service';
import { Script } from '../../../script-interpreter/models/interfaces/script';
import { Parameter } from '../../../script-interpreter/models/interfaces/parameter';
import { ParameterOptions } from '../../../script-interpreter/models/enums/parameterOptions';
import { ValueType } from '../../../script-interpreter/models/enums/valueType';


const ScriptId = 10;

@Component({
    selector: 'snow-load-monopitch-roof',
    templateUrl: './snow-load-monopitch-roof.component.html',
    styleUrls: ['./snow-load-monopitch-roof.component.scss']
})
export class SnowLoadMonopitchRoofComponent implements OnInit {
    script: Script;
    parameters: Parameter[];
    addition: number = 0;
    resultParameters: Parameter[] = [];

    parameterOptions = ParameterOptions;

    offset: number = 80;

    valueTypes = ValueType;

    get snowFences(): Parameter {
        return this.parameters.find(p => p.name == "SnowFences");
    }
    get slope(): Parameter {
        return this.parameters.find(p => p.name == "α");
    }
    get altitude(): Parameter {
        return this.parameters.find(p => p.name == "A");
    }
    get zone(): Parameter {
        return this.parameters.find(p => p.name == "Zone");
    }
    get topography(): Parameter {
        return this.parameters.find(p => p.name == "Topography");
    }
    get snowLoad(): Parameter {
        return this.resultParameters.find(p => p.name == "s");
    }

    constructor(private route: ActivatedRoute,
        private scriptService: ScriptService,
        private parameterService: ParameterService,
        private calculationService: CalculationService,
        private translationService: TranslationService) {
    }

    ngOnInit(): void {
        this.getScript();
        this.getParameters();

        this.translationService.languageChanged$.subscribe(language => {
            this.getScript();
            this.getParameters();
        });
    }

    private getScript() {
        this.scriptService.getScript(ScriptId).subscribe(script => {
            this.script = script;
        }, error => console.error(error));
    }

    private getParameters() {
        this.parameterService.getParameters(ScriptId, this.translationService.getCurrentLanguage())
            .subscribe(parameters => {
                this.parameters = parameters.filter(p => (p.context & ParameterOptions.editable) != 0);
            }, error => console.error(error));
    }

    onSlopeChange() {
        this.setAddition();
        this.calculate();
    }

    setAddition() {
        this.addition = Math.min(Math.tan(+this.slope.value * Math.PI / 180) * 300 / 5, 175);
    }

    isRequired(parameter: Parameter): boolean {
        return (parameter.context & this.parameterOptions.optional) == 0;
    }

    calculate() {
        this.calculationService.calculate(ScriptId, this.parameters)
            .subscribe(parameters => {
                this.resultParameters = parameters
            }, error => console.error(error));
    }

    onMouseOver($event) {
        $event.srcElement.style.fill = "white";
        $event.srcElement.style.backgroundColor = "white";
        $event.srcElement.style.opacity = "0.3";
    }

    selectZone(zoneNumber: number) {
        if (zoneNumber == 1)
            this.zone.value = "FirstZone";
        else if (zoneNumber == 2)
            this.zone.value = "SecondZone";
        else if (zoneNumber == 3)
            this.zone.value = "ThirdZone";
        else if (zoneNumber == 4)
            this.zone.value = "FourthZone";
        else if (zoneNumber == 5)
            this.zone.value = "FifthZone";
    }
}
