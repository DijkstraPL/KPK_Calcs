import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { MatRadioChange } from '@angular/material/radio';

@Component({
    selector: 'parameter-radio',
    templateUrl: './parameter-radio.component.html',
    styleUrls: ['./parameter-radio.component.less']
})

export class ParameterRadioComponent implements OnInit {

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    constructor() {
    }

    ngOnInit(): void {
      
    }

    changeValue(event: MatRadioChange): void {
        this.parameter.value = event.value;
        this.valueChanged.emit(this.parameter);
    }
}