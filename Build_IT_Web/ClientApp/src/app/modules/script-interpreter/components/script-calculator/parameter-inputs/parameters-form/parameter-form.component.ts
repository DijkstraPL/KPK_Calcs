import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ValueOptionSettings } from '../../../../models/enums/valueOptionSettings';

@Component({
    selector: 'parameter-form',
    templateUrl: './parameter-form.component.html',
    styleUrls: ['./parameter-form.component.scss']
})

export class ParameterFormComponent implements OnInit {

    valueOptionSetting = ValueOptionSettings;

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    constructor() {
    }

    ngOnInit(): void {
      
    }

    onValueChanged(parameter: Parameter): void {
        this.valueChanged.emit(parameter);
    }
}