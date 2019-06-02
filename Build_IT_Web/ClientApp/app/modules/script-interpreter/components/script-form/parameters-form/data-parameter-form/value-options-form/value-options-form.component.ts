import { Component, Input } from '@angular/core';
import { FormGroup, FormArray, FormControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../../common/errors/app-error-state-matcher';

@Component({
    selector: 'app-value-options-form',
    templateUrl: './value-options-form.component.html',
    styleUrls: ['./value-options-form.component.scss']
})

export class ValueOptionsFormComponent {
  
    @Input('parameterForm') parameterForm: FormGroup;

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
                name: new FormControl(''),
                value: new FormControl(''),
                description: new FormControl('')
            }));

        console.log('value otpions',this.parameterValueOptions);
    }

    remove(valueOption: FormGroup) {
        const index = this.parameterValueOptions.controls.indexOf(valueOption);

        if (index >= 0) {
            this.parameterValueOptions.removeAt(index);
        }
    }
}