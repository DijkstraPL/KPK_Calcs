import { Component, Input, OnInit } from '@angular/core';
import { AppErrorStateMatcher } from '../../../../../../../common/errors/app-error-state-matcher';
import { Parameter } from '../../../../../models/interfaces/parameter';
import { ParameterService } from '../../../../../services/parameter.service';
import { FormGroup, AbstractControl } from '@angular/forms';

@Component({
    selector: 'app-value-form',
    templateUrl: './value-form.component.html',
    styleUrls: ['./value-form.component.scss']
})

export class ValueFormComponent implements OnInit {
    matcher = new AppErrorStateMatcher();

    @Input('parameterForm') parameterForm: FormGroup;
    @Input('scriptId') scriptId: number;
    @Input('fieldName') fieldName: string;
    @Input('parameters') parameters: Parameter[];
    previousParameters: Parameter[];

    get parameterNumber(): AbstractControl {
        return this.parameterForm.get('number');
    }
    get field(): AbstractControl {
        return this.parameterForm.get(this.fieldName);
    }
      
   
    private colors: string[] = ["yellow", "red", "green"];

    constructor(private parameterService: ParameterService) {
    }

    ngOnInit(): void {
        this.previousParameters = this.parameters.filter(p => p.number < this.parameterNumber.value);
    }
}
