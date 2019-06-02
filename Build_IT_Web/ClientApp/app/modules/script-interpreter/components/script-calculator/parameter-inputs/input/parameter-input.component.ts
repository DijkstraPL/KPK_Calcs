import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';

@Component({
    selector: 'parameter-input',
    templateUrl: './parameter-input.component.html',
    styleUrls: ['./parameter-input.component.scss']
})

export class ParameterInputComponent implements OnInit {

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    parameterOptions = ParameterOptions;

    constructor() {
    }

    ngOnInit(): void {
      
    }

    changeValue(): void {
        this.valueChanged.emit(this.parameter);
    }

    isRequired(): boolean {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    }
}