import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { MatRadioChange } from '@angular/material/radio';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';

@Component({
    selector: 'parameter-radio',
    templateUrl: './parameter-radio.component.html',
    styleUrls: ['./parameter-radio.component.scss']
})

export class ParameterRadioComponent implements OnInit {

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    parameterOptions = ParameterOptions;

    constructor() {
    }

    ngOnInit(): void {
      
    }

    changeValue(event: MatRadioChange): void {
        this.parameter.value = event.value;
        this.valueChanged.emit(this.parameter);
    }

    isRequired(): boolean {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    }
}