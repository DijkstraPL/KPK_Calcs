import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../models/enums/language';

@Component({
    selector: 'script-data-form',
    templateUrl: './script-data-form.component.html',
    styleUrls: ['./script-data-form.component.scss']
})

export class ScriptDataFormComponent {
    @Input('scriptForm') scriptForm: FormGroup;
    @Input('includeNote') includeNote: boolean;

    languages = Language;

    matcher = new AppErrorStateMatcher();

    get scriptName(): AbstractControl {
        return this.scriptForm.get('name');
    }
    get scriptDocument(): AbstractControl {
        return this.scriptForm.get('accordingTo');
    }
    get scriptGroup(): AbstractControl {
        return this.scriptForm.get('groupName');
    }
    get scriptDescription(): AbstractControl {
        return this.scriptForm.get('description');
    }
    get scriptNotes(): AbstractControl {
        return this.scriptForm.get('notes');
    }
    get scriptDefaultLanguage(): AbstractControl {
        return this.scriptForm.get('defaultLanguage');
    }
    get scriptIsPublic(): AbstractControl {
        return this.scriptForm.get('isPublic');
    }
}
