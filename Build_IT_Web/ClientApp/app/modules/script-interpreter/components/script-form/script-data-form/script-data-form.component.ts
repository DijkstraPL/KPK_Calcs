import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';

@Component({
    selector: 'script-data-form',
    templateUrl: './script-data-form.component.html',
    styleUrls: ['./script-data-form.component.scss']
})

export class ScriptDataFormComponent {
    @Input('scriptForm') scriptForm: FormGroup;
   // @Input('includeNote') includeNote: boolean;
    includeNote: boolean;

    matcher = new AppErrorStateMatcher();

    get scriptName(): AbstractControl {
        return this.scriptForm.get('name');
    }
    get scriptAuthor(): AbstractControl {
        return this.scriptForm.get('author');
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
    set scriptNotes(value) {
        this.scriptForm.controls['notes'].setValue(value);
        this.includeNote = this.scriptNotes.value != null && this.scriptNotes.value != '';
    }

}