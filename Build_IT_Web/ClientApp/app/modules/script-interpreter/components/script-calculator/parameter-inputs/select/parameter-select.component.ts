import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';

@Component({
    selector: 'parameter-select',
    templateUrl: './parameter-select.component.html',
    styleUrls: ['./parameter-select.component.scss']
})

export class ParameterSelectComponent implements OnInit {

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