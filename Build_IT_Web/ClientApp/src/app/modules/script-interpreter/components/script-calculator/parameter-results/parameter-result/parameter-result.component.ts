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
    @Input('parameter') parameter: Parameter = null;
    //valueClass: string;
    //forbiddenSigns = ['(', ')', ',', '.', '^'];

    valueTypes = ValueType;
    isValid: boolean;
    isNotValid: boolean;

    parameterEquation: string;

    constructor() {
    }

    ngOnInit(): void {
        if (this.parameter.dataValidator && this.parameter.dataValidator.length > 0) {
            this.isValid = this.parameter.dataValidator == "True";
            this.isNotValid = this.parameter.dataValidator != "True";
        }
        
        // this.forbiddenSigns.forEach(fs => this.valueClass = this.parameter.name.replace(fs, ''));
    }

    isImportant(): boolean {
        return (this.parameter.context & ParameterOptions.important) != 0
    }
}
