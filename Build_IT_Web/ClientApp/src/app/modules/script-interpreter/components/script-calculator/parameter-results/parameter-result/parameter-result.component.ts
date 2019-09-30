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

    parameterEquation: string;

    valueTypesMapping: { [key: string]: number } =
        { 'number': 0, 'text': 1 };

    constructor() {
    }

    ngOnInit(): void {
       // this.forbiddenSigns.forEach(fs => this.valueClass = this.parameter.name.replace(fs, ''));
    }

    isImportant(): boolean {
        return (this.parameter.context & ParameterOptions.important) != 0
    }
}