import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ValueType } from '../../../../models/enums/valueType';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';

@Component({
    selector: 'parameter-result',
    templateUrl: './parameter-result.component.html',
    styleUrls: ['./parameter-result.component.scss']
})

export class ParameterResultComponent implements OnInit {
    valueTypes = ValueType;
    
    @Input() parameter: Parameter = null;

    constructor() {
    }

    ngOnInit(): void {
      
    }

    isImportant(): boolean {
        return (this.parameter.context & ParameterOptions.important) != 0
    }
}