import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';

@Component({
    selector: 'parameter-input',
    templateUrl: './parameter-input.component.html',
    styleUrls: ['./parameter-input.component.scss']
})

export class ParameterInputComponent implements OnInit {

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    constructor() {
    }

    ngOnInit(): void {
      
    }

    changeValue(): void {
        this.valueChanged.emit(this.parameter);
    }
}