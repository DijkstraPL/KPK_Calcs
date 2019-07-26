import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ScriptService } from '../../../script-interpreter/services/script.service';
import { ParameterService } from '../../../script-interpreter/services/parameter.service';
import { CalculationService } from '../../../script-interpreter/services/calculation.service';
import { TranslationService } from '../../../../services/translation.service';
import { Script } from '../../../script-interpreter/models/interfaces/script';
import { Parameter } from '../../../script-interpreter/models/interfaces/parameter';


const ScriptId = 10;

@Component({
    selector: 'snow-load-monopitch-roof',
    templateUrl: './snow-load-monopitch-roof.component.html',
    styleUrls: ['./snow-load-monopitch-roof.component.scss']
})
export class SnowLoadMonopitchRoofComponent implements OnInit {
    script: Script;
    parameters: Parameter[];   
    addition: number;

    get snowFences() {
        return this.parameters.find(p => p.name == "SnowFences");
    }
    get slope() {
        return this.parameters.find(p => p.name == "α");
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
                this.parameters = parameters
            }, error => console.error(error));
    }

    setAddition() {
        this.addition = Math.tan(+this.slope.value * Math.PI / 180) * 300 / 5;
    }
}