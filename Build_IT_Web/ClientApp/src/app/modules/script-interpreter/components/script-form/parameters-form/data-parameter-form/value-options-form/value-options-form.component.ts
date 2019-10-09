import { Component, Input } from '@angular/core';
import { FormGroup, FormArray, FormControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../../common/errors/app-error-state-matcher';
import { ValueOptionSettings } from '../../../../../models/enums/valueOptionSettings';
import { MatRadioChange } from '@angular/material/radio';

@Component({
    selector: 'app-value-options-form',
    templateUrl: './value-options-form.component.html',
    styleUrls: ['./value-options-form.component.scss']
})

export class ValueOptionsFormComponent {

    @Input('parameterForm') parameterForm: FormGroup;

    valueOptionSettings = ValueOptionSettings;

    get parameterValueOptionSetting() {
        return this.parameterForm.get('valueOptionSetting');
    }
    get parameterValueOptions() {
        return this.parameterForm.get('valueOptions') as FormArray;
    }

    matcher = new AppErrorStateMatcher();

    constructor() {
    }

    addValueOption() {
        this.parameterValueOptions.push(
            new FormGroup({
                id: new FormControl(0),
                number: new FormControl(0),
                name: new FormControl(''),
                value: new FormControl(''),
                description: new FormControl('')
            }));
    }

    remove(valueOption: FormGroup) {
        const index = this.parameterValueOptions.controls.indexOf(valueOption);

        if (index >= 0) {
            this.parameterValueOptions.removeAt(index);
        }
    }

    booleanSettingChecked(checkbox: MatRadioChange) {
        if (checkbox.value == this.valueOptionSettings.Boolean)
            while (this.parameterValueOptions.length !== 0) {
                this.parameterValueOptions.removeAt(0)
        }
    }
}
