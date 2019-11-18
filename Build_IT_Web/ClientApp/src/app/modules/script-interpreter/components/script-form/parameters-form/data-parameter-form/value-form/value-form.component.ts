import { Component, Input, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AppErrorStateMatcher } from '../../../../../../../common/errors/app-error-state-matcher';
import { Parameter } from '../../../../../models/interfaces/parameter';
import { ParameterService } from '../../../../../services/parameter.service';
import { FormGroup, AbstractControl } from '@angular/forms';
import { HtmlPipe } from '../../../../../../pipes-module/text-pipes/html-pipe';

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

    set fieldValue(value: string) {
        this.field.setValue(value);
    }

    private _styledValue: string;
    get styledValue(): string {
        return this._styledValue;
    }

    @ViewChild('element', { static: false }) element: ElementRef;

    private colors: string[] = ["yellow", "red", "green"];

    constructor(private parameterService: ParameterService,
        private htmlPipe: HtmlPipe) {
    }

    ngOnInit(): void {
        this.previousParameters = this.parameters.filter(p => p.number < this.parameterNumber.value);
        this._styledValue = this.getStyledValue();
    }

    private getStyledValue(): string {
        let styledValue = "";
        let parameter = "";
        let insideParameter = false;
        let index = 0;
        for (var i = 0; i < this.field.value.length; i++) {
            if (insideParameter && this.field.value[i] == "]") {
                styledValue += `<span class="parameter" contenteditable="false" style="color:red">${this.htmlPipe.transform(parameter)}</span>`;
                parameter = "";
                insideParameter = false;
                continue;
            }
            else if (this.field.value[i] == "[") {
                insideParameter = true;
                continue;
            }
            else if (insideParameter) {
                parameter += this.field.value[i];
                continue;
            }


            if (this.field.value[i] == "(")
                styledValue += `<span class="openingBracket" contenteditable="false" style="color:${this.colors[index++]}">(</span>`;
            else if (this.field.value[i] == ")")
                styledValue += `<span class="closingBracket" contenteditable="false" style="color:${this.colors[--index]}">)</span>`;
            else
                styledValue += this.field.value[i];
        }

        return styledValue;
    }

    select(parameter: Parameter) {
        let position = this.element.nativeElement.selectionEnd;
        
        if (position >= 0) {
            let value = this.field.value as string;
            this.field.setValue(
                value.slice(0, position) + `[${parameter.name}]` + value.slice(position));
            this._styledValue = this.getStyledValue();

            this.element.nativeElement.focus();
            this.element.nativeElement.selectionEnd = position + `[${parameter.name}]`.length;
        }
        else {
            this.field.setValue(`${this.field.value}[${parameter.name}]`);
            this._styledValue = this.getStyledValue();

            this.element.nativeElement.focus();
            this.element.nativeElement.selectionEnd = this.field.value.length;
        }
    }

    private ConvertToValue() {
        let value = "";
        for (let childNode of this.element.nativeElement.childNodes) {
            if (childNode.nodeName == "#text")
                value += childNode.textContent;
            else if (childNode.className == "openingBracket")
                value += "(";
            else if (childNode.className == "closingBracket")
                value += ")";
            else if (childNode.className == "parameter")
                value += `[${this.htmlPipe.transform(childNode.innerHTML)
                    .replace("<sub>", "_").replace("</sub>", "_")
                    .replace("<sup>", "^").replace("</sup>", "^")}]`;
        }

        this.field.setValue(value);
    }

    changed() {
        this.ConvertToValue();  
    } 
}
