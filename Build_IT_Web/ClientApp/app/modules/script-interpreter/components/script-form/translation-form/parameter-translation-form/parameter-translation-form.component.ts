import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../../models/enums/language';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterTranslationService } from '../../../../services/translations/parameter-translation.service';

@Component({
    selector: 'app-parameter-translation-form',
    templateUrl: './parameter-translation-form.component.html',
    styleUrls: ['./parameter-translation-form.component.scss']
})

export class ParameterTranslationFormComponent implements OnInit {

    @Input('scriptForm') scriptForm: FormGroup;
    @Input('translationForm') translationForm: FormGroup;
    @Input('defaultLanguage') defaultLanguage: Language;
    @Input('translationData') translationData: { editMode: boolean, scriptId: number };

    parametersTranslationsForm = new FormArray([
        new FormGroup({
            id: new FormControl('0'),
            parameterId: new FormControl('0'),
            description: new FormControl(),
            notes: new FormControl(),
            groupName: new FormControl(),
            language: new FormControl('0')
        })
    ]);

    languages = Language;
    matcher = new AppErrorStateMatcher();
    parameters: Parameter[];

    get translationLanguage(): AbstractControl {
        return this.translationForm.get('language');
    }


    constructor(private parameterTranslationService: ParameterTranslationService,
        private parameterService: ParameterService) {
    }

    ngOnInit(): void {
        this.getParameters();
        this.getParametersTranslations();
    }

    getParametersTranslations() {
        this.parameterTranslationService.getParametersTranslation(this.translationData.scriptId, this.translationLanguage.value)
            .subscribe(parametersTranslations => {
                console.log(parametersTranslations);
                this.parametersTranslationsForm.patchValue(parametersTranslations);
                console.log(this.parametersTranslationsForm);
            });
    }

    getParameters() {
        this.parameterService.getParameters(this.translationData.scriptId, this.translationLanguage.value)
            .subscribe(parameters => {
                this.parameters = parameters;
            });
    }
}