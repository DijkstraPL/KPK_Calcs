import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';

@Component({
    selector: 'parameter-select',
    templateUrl: './parameter-select.component.html',
    styleUrls: ['./parameter-select.component.scss']
})

export class ParameterSelectComponent implements OnInit {

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