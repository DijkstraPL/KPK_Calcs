import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';
import { ActivatedRoute } from '@angular/router';
import { Language } from '../../../models/enums/language';
import { ScriptTranslationService } from '../../../services/translations/script-translation.service';
import { ScriptTranslation } from '../../../models/interfaces/translations/scriptTranslation';
import { ParameterService } from '../../../services/parameter.service';

@Component({
    selector: 'app-translation-form',
    templateUrl: './translation-form.component.html',
    styleUrls: ['./translation-form.component.scss']
})

export class TranslationFormComponent implements OnInit {
    translationForm = new FormGroup({
        id: new FormControl('0'),
        scriptId: new FormControl(''),
        language: new FormControl('0', Validators.required),
        name: new FormControl('', Validators.maxLength(100)),
        description: new FormControl('', Validators.maxLength(500)),
        notes: new FormControl('', Validators.maxLength(1000))
    });

    @Input('defaultLanguage') defaultLanguage: Language;
    @Input('scriptForm') scriptForm: FormGroup;
    languages = Language;

    scriptId: number;
    matcher = new AppErrorStateMatcher();
    editMode: boolean;
    parameters: any;

    get originalName(): AbstractControl {
        return this.scriptForm.get('name');
    }
    get originalDescription(): AbstractControl {
        return this.scriptForm.get('description');
    }
    get originalNotes(): AbstractControl {
        return this.scriptForm.get('notes');
    }
    get originalDefaultLanguage(): AbstractControl {
        return this.scriptForm.get('defaultLanguage');
    }

    get translationId(): AbstractControl {
        return this.translationForm.get('id');
    }
    get translationScriptId(): AbstractControl {
        return this.translationForm.get('scriptId');
    }
    get translationName(): AbstractControl {
        return this.translationForm.get('name');
    }
    get translationDescription(): AbstractControl {
        return this.translationForm.get('description');
    }
    get translationNotes(): AbstractControl {
        return this.translationForm.get('notes');
    }
    get translationLanguage(): AbstractControl {
        return this.translationForm.get('language');
    }

    constructor(private scriptTranslationService: ScriptTranslationService,
       // private parameterTranslationService: ParameterTranslationService,
        private parameterService: ParameterService,
        private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.scriptId = +params['id'];
        });

        this.translationScriptId.setValue(this.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);

        this.getScriptTranslation(this.translationLanguage.value);
        this.getParameters();
        this.getParametersTranslations(this.translationLanguage.value);
    }

    onLanguageChange($event) {
        this.getScriptTranslation($event.value);
    }

    private getScriptTranslation(language: Language) {
        this.scriptTranslationService.getScriptTranslation(this.scriptId, language)
            .subscribe(translation => {
                if (translation) {
                    this.translationForm.patchValue(translation);
                    this.editMode = true;
                }
                else
                    this.editMode = false;
            });
    }

    private getParametersTranslations(language: Language) {
        //this.parameterTranslationService
    }

    onScriptTranslationSubmit() {
        if (!this.editMode)
            this.scriptTranslationService.create(this.translationForm.value)
                .subscribe((scriptTranslation: ScriptTranslation) => {
                    this.translationForm.patchValue(scriptTranslation);
                    this.editMode = true;
                }, error => { throw error });
        else
            this.scriptTranslationService.update(this.translationForm.value)
                .subscribe((scriptTranslation: ScriptTranslation) => this.translationForm.patchValue(scriptTranslation));
    }

    removeScriptTranslation() {
        let selectedLanguage = this.translationLanguage.value;
        this.scriptTranslationService.remove(this.translationId.value)
            .subscribe((scriptTranslation: ScriptTranslation) => {
                this.translationForm.reset();
                this.editMode = false;
                this.translationScriptId.setValue(this.scriptId);
                this.translationLanguage.setValue(selectedLanguage);
            });
    }
    
    getParameters() {
        this.parameterService.getParameters(this.scriptId, this.originalDefaultLanguage.value).subscribe(parameters => {
            this.parameters = parameters;
        }, error => console.error(error));
    }
}