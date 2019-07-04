import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../models/enums/language';
import { ScriptTranslation } from '../../../models/interfaces/translations/scriptTranslation';
import { ScriptTranslationService } from '../../../services/translations/script-translation.service';

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

    matcher = new AppErrorStateMatcher();
    translationData = { editMode: false, scriptId: 0 };

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
        private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.translationData.scriptId = +params['id'];
        });

        this.translationScriptId.setValue(this.translationData.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);
    }

    onScriptTranslationSubmit() {
        if (!this.translationData.editMode)
            this.scriptTranslationService.create(this.translationForm.value)
                .subscribe((scriptTranslation: ScriptTranslation) => {
                    this.translationForm.patchValue(scriptTranslation);
                    this.translationData.editMode = true;
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
                this.translationData.editMode = false;
                this.translationScriptId.setValue(this.translationData.scriptId);
                this.translationLanguage.setValue(selectedLanguage);
            });
    }
}