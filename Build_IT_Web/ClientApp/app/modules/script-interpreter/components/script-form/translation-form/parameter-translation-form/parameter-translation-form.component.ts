import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup } from '@angular/forms';
import { forkJoin, Observable } from 'rxjs';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../../models/enums/language';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterTranslation } from '../../../../models/interfaces/translations/parameterTranslation';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterTranslationService } from '../../../../services/translations/parameter-translation.service';
import { ValueOptionTranslation } from '../../../../models/interfaces/translations/valueOptionTranslation';
import { ValueOption } from '../../../../models/interfaces/valueOption';
import { ValueOptionTranslationService } from '../../../../services/translations/value-option-translation.service';

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
    mappedParameters: {
        parameter: Parameter, translation: ParameterTranslation,
        valueOptions: { origin: ValueOption, translation: ValueOptionTranslation }[]
    }[] = [];

    get translationLanguage(): AbstractControl {
        return this.translationForm.get('language');
    }

    constructor(private parameterTranslationService: ParameterTranslationService,
        private valueOptionTranslationService: ValueOptionTranslationService,
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
        this.mappedParameters = [];
        let parametersTranslation = this.parametersTranslationsForm.value as ParameterTranslation[];
        this.parameters.forEach(p => {
            let mappedParameter = {
                parameter: p, translation: parametersTranslation.find(pt => pt.parameterId == p.id) ||
                    new FormGroup({
                        id: new FormControl('0'),
                        parameterId: new FormControl(p.id),
                        description: new FormControl(''),
                        notes: new FormControl(''),
                        groupName: new FormControl(''),
                        language: new FormControl(this.translationLanguage.value)
                    }).value as ParameterTranslation,
                valueOptions: []
            };
            this.mappedParameters.push(mappedParameter);
        });

        this.setValueOptions();
    }

    setValueOptions() {
        this.mappedParameters.forEach(mp => {
            this.valueOptionTranslationService.getValueOptionsTranslations(mp.parameter.id, this.translationLanguage.value)
                .subscribe((vot: ValueOptionTranslation[]) => {
                    mp.parameter.valueOptions.forEach((vo: ValueOption) => {
                        mp.valueOptions.push({
                            origin: vo, translation: vot.find(v => v.valueOptionId == vo.id) || new FormGroup({
                                id: new FormControl(0),
                                valueOptionId: new FormControl(vo.id),
                                name: new FormControl(''),
                                description: new FormControl(''),
                                language: new FormControl(this.translationLanguage.value)
                            }).value as ValueOptionTranslation
                        });
                    });
                });
        });
    }

    getParametersTranslations(): Observable<ParameterTranslation[]> {
        return this.parameterTranslationService.getParametersTranslation(this.translationData.scriptId, this.translationLanguage.value);
    }

    getParameters(): Observable<Parameter[]> {
        return this.parameterService.getParameters(this.translationData.scriptId, this.translationLanguage.value);
    }

    parametersSubmit() {
        this.mappedParameters.forEach(mp => {
            if (mp.translation.id == 0 && mp.translation.description)
                this.createParameterTranslation(mp.translation);
            else if (mp.translation.description)
                this.updateParameterTranslation(mp.translation);

            mp.valueOptions.forEach(vo => {
                if (vo.translation.id == 0 && (vo.translation.name || vo.translation.description))
                    this.createValueOptionTranslation(vo.translation);
                else if (vo.translation.name || vo.translation.description)
                    this.updateValueOptionTranslation(vo.translation);
            });
        });
    }

    updateValueOptionTranslation(valueOptionTranslation: ValueOptionTranslation) {
        this.valueOptionTranslationService.update(valueOptionTranslation)
            .subscribe(vot => { });
    }

    createValueOptionTranslation(valueOptionTranslation: ValueOptionTranslation) {
        this.valueOptionTranslationService.create(valueOptionTranslation)
            .subscribe(vot => { });
    }

    updateParameterTranslation(parameterTranslation: ParameterTranslation) {
        this.parameterTranslationService.update(parameterTranslation)
            .subscribe((updatedTranslation: ParameterTranslation) => {
                this.parametersTranslationsForm.clear();

                this.parametersTranslationsForm.push(new FormGroup({
                    id: new FormControl(updatedTranslation.id),
                    parameterId: new FormControl(updatedTranslation.parameterId),
                    description: new FormControl(updatedTranslation.description),
                    notes: new FormControl(updatedTranslation.notes),
                    groupName: new FormControl(updatedTranslation.groupName),
                    language: new FormControl(updatedTranslation.language)
                }));
            });
    }

    createParameterTranslation(parameterTranslation: ParameterTranslation) {
        this.parameterTranslationService.create(parameterTranslation)
            .subscribe((newTranslation: ParameterTranslation) => {
                this.parametersTranslationsForm.clear();
                this.parametersTranslationsForm.push(new FormGroup({
                    id: new FormControl(newTranslation.id),
                    parameterId: new FormControl(newTranslation.parameterId),
                    description: new FormControl(newTranslation.description),
                    notes: new FormControl(newTranslation.notes),
                    groupName: new FormControl(newTranslation.groupName),
                    language: new FormControl(newTranslation.language)
                }));
            });
    }
}