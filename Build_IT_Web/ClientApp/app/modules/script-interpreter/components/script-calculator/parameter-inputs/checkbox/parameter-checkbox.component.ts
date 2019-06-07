import { Component, OnInit, EventEmitter, Output, Input, ViewChild } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
import { MatCheckboxChange, MatCheckbox } from '@angular/material/checkbox';

@Component({
    selector: 'parameter-checkbox',
    templateUrl: './parameter-checkbox.component.html',
    styleUrls: ['./parameter-checkbox.component.scss']
})

export class ParameterCheckboxComponent implements OnInit {

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    parameterOptions = ParameterOptions;
    isDefault: boolean;

    @ViewChild('defaultField') defaultField: MatCheckbox;
    @ViewChild('checkboxField') checkboxField: MatCheckbox;

    constructor() {
    }

    ngOnInit(): void {
        if (this.isRequired() && this.parameter.value != 'true')
            this.parameter.value = 'false';
    }

    ngAfterViewInit() {
        if (!this.isRequired())
            this.defaultField.checked = this.parameter.value == '';
        else
            this.checkboxField.checked = this.parameter.value == 'true';

        if (this.defaultField)
            this.isDefault = this.defaultField.checked;
    }

    changeValue(event: MatCheckboxChange): void {
        this.parameter.value = event.checked ? 'true' : 'false';
        this.valueChanged.emit(this.parameter);
    }

    isRequired(): boolean {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    }

    defaultChecked(event: MatCheckboxChange) {
        if (event.checked) {
            this.parameter.value = null;
            this.isDefault = true;
        }
        else
            this.isDefault = false;

        this.valueChanged.emit(this.parameter);
    }
}