import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Language } from '../../../../models/enums/language';
import { ScriptTranslationService } from '../../../../services/translations/script-translation.service';
import { ScriptTranslation } from '../../../../models/interfaces/translations/scriptTranslation';
import { ParameterService } from '../../../../services/parameter.service';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';

@Component({
    selector: 'app-script-translation-form',
    templateUrl: './script-translation-form.component.html',
    styleUrls: ['./script-translation-form.component.scss']
})

export class ScriptTranslationFormComponent implements OnInit {

    @Input('scriptForm') scriptForm: FormGroup;
    @Input('translationForm') translationForm: FormGroup;
    @Input('defaultLanguage') defaultLanguage: Language;
    @Input('translationData') translationData: { editMode: boolean, scriptId: number };

    languages = Language;

    matcher = new AppErrorStateMatcher();

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
        this.translationScriptId.setValue(this.translationData.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);

        this.getScriptTranslation(this.translationLanguage.value);
    }

    onLanguageChange($event) {
        this.getScriptTranslation($event.value);
    }

    private getScriptTranslation(language: Language) {
        this.scriptTranslationService.getScriptTranslation(this.translationData.scriptId, language)
            .subscribe(translation => {
                if (translation) {
                    this.translationForm.patchValue(translation);
                    this.translationData.editMode = true;
                }
                else
                    this.translationData.editMode = false;
            });
    }
}