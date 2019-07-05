import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup } from '@angular/forms';
import { forkJoin, Observable } from 'rxjs';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../../models/enums/language';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterTranslation } from '../../../../models/interfaces/translations/parameterTranslation';
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
    mappedParameters: { parameter: Parameter, translation: ParameterTranslation }[] = [];

    get translationLanguage(): AbstractControl {
        return this.translationForm.get('language');
    }
    
    constructor(private parameterTranslationService: ParameterTranslationService,
        private parameterService: ParameterService) {
    }

    ngOnInit(): void {
        let parameters$ = this.getParameters();
        let parametersTranslations$ = this.getParametersTranslations();

        forkJoin([parameters$, parametersTranslations$]).subscribe(results => {
            this.parameters = results[0];
            results[1].forEach(pt => this.parametersTranslationsForm.push(new FormGroup({
                id: new FormControl(pt.id),
                parameterId: new FormControl(pt.parameterId),
                description: new FormControl(pt.description),
                notes: new FormControl(pt.notes),
                groupName: new FormControl(pt.groupName),
                language: new FormControl(pt.language)
            })));
            this.setMappedParameters();
        });
    }

    setMappedParameters() {
        let parametersTranslation = this.parametersTranslationsForm.value as ParameterTranslation[];
        this.parameters.forEach(p => {
            let mappedParameter = { parameter: p, translation: parametersTranslation.find(pt => pt.parameterId == p.id) };
            console.log(mappedParameter);
            this.mappedParameters.push(mappedParameter);
            console.log(this.mappedParameters);
        });
    }

    getParametersTranslations(): Observable<ParameterTranslation[]> {
        return this.parameterTranslationService.getParametersTranslation(this.translationData.scriptId, this.translationLanguage.value);
    }

    getParameters(): Observable<Parameter[]> {
        return this.parameterService.getParameters(this.translationData.scriptId, this.translationLanguage.value);
    }
}