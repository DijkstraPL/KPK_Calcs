import { Component, ElementRef, EventEmitter, Input, OnInit, Output, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatRadioButton } from '@angular/material/radio';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
import { ValueOptionSettings } from '../../../../models/enums/valueOptionSettings';
import { ValueType } from '../../../../models/enums/valueType';
import { EnumObject } from '../../../../models/interfaces/enumObject';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ValueOption } from '../../../../models/interfaces/valueOption';
import { ParameterImpl } from '../../../../models/parameterImpl';
import { ValueOptionImpl } from '../../../../models/valueOptionImpl';
import { ParameterService } from '../../../../services/parameter.service';

@Component({
    selector: 'app-data-parameter-form',
    templateUrl: './data-parameter-form.component.html',
    styleUrls: ['./data-parameter-form.component.scss']
})

export class DataParameterFormComponent implements OnInit {
    parameterForm = new FormGroup({
        id: new FormControl('0'),
        name: new FormControl('', [Validators.required, Validators.maxLength(20)]),
        number: new FormControl('', Validators.required),
        description: new FormControl('', Validators.maxLength(1000)),
        valueType: new FormControl('', Validators.required),
        value: new FormControl('', Validators.maxLength(1000)),
        visibilityValidator: new FormControl('', Validators.maxLength(1000)),
        dataValidator: new FormControl('', Validators.maxLength(1000)),
        unit: new FormControl('', Validators.maxLength(50)),
        context: new FormControl('3', Validators.required),
        groupName: new FormControl('', Validators.maxLength(200)),
        accordingTo: new FormControl('', Validators.maxLength(200)),
        notes: new FormControl('', Validators.maxLength(1000)),
        valueOptionSetting: new FormControl(0),
        valueOptions: new FormArray([]),
        figures: new FormArray([]),
    });

    matcher = new AppErrorStateMatcher();

    @Input('newlyAddedParameter') newlyAddedParameter: boolean;
    @Input('scriptId') scriptId: number;
    @Input('newParameter') newParameter: Parameter = new ParameterImpl();
    @Input('parameters') parameters: Parameter[];
     previousParameters: Parameter[];

    @Output('created') created = new EventEmitter<Parameter>();
    @Output('updated') updated = new EventEmitter<Parameter>();

    valueTypes = this.getEnumValues(ValueType);
    context = ParameterOptions;

    @ViewChild('editable', { static: true }) editable: MatRadioButton;
    @ViewChild('static', { static: true }) static: MatRadioButton;
    @ViewChild('calculable', { static: true }) calculable: MatRadioButton;
    @ViewChild('visible', { static: true }) visible: MatCheckbox;
    @ViewChild('important', { static: true }) important: MatCheckbox;
    @ViewChild('optional', { static: true }) optional: MatCheckbox;

    @ViewChild('value', { static: false }) value: ElementRef;
    
    get parameterId(): AbstractControl {
        return this.parameterForm.get('id');
    }
    get parameterName(): AbstractControl {
        return this.parameterForm.get('name');
    }
    get parameterNumber(): AbstractControl {
        return this.parameterForm.get('number');
    }
    get parameterUnit(): AbstractControl {
        return this.parameterForm.get('unit');
    }
    get parameterDocument(): AbstractControl {
        return this.parameterForm.get('accordingTo');
    }
    get parameterValueType(): AbstractControl {
        return this.parameterForm.get('valueType');
    }
    get parameterValue(): AbstractControl {
        return this.parameterForm.get('value');
    }
    get parameterDescription(): AbstractControl {
        return this.parameterForm.get('description');
    }
    get parameterVisibilityValidator(): AbstractControl {
        return this.parameterForm.get('visibilityValidator');
    }
    get parameterDataValidator(): AbstractControl {
        return this.parameterForm.get('dataValidator');
    }
    get parameterContext(): AbstractControl {
        return this.parameterForm.get('context');
    }
    get parameterValueOptions(): FormArray {
        return this.parameterForm.get('valueOptions') as FormArray;
    }
    get parameterGroupName(): AbstractControl {
        return this.parameterForm.get('groupName');
    }
    get parameterFigures(): FormArray {
        return this.parameterForm.get('figures') as FormArray;
    }
    get styledValue(): string {
        return this.getStyledValue();
    }

    private colors: string[] = ["yellow", "red", "green"];

    constructor(private parameterService: ParameterService) {
    }

    ngOnInit(): void {
        this.previousParameters = this.parameters.filter(p => p.number < this.parameterNumber.value);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes.newParameter) {
            let parameter = changes.newParameter.currentValue as Parameter;
            this.parameterForm.patchValue(parameter);

            parameter.valueOptions.forEach(vo => this.parameterValueOptions.push(new FormGroup({
                id: new FormControl(vo.id),
                number: new FormControl(vo.number),
                name: new FormControl(vo.name),
                value: new FormControl(vo.value),
                description: new FormControl(vo.description)
            })));

            parameter.figures.forEach(f => this.parameterFigures.push(new FormGroup({
                id: new FormControl(f.id),
                fileName: new FormControl(f.fileName),
            })));

            this.setNewParameterChanges(changes.newParameter);
        }

        if (changes.editMode)
            this.newlyAddedParameter = changes.editMode.currentValue;

    }

    private setNewParameterChanges(newParameter: SimpleChange) {
        console.log('Previous parameter: ', newParameter.previousValue);
        console.log('New parameter: ', newParameter.currentValue);
        this.newParameter = newParameter.currentValue;
        // this.setDataType();
        this.setValueOptionsSettings();
        this.setParameterType();
    }

    private getEnumValues(e: EnumObject) {
        return Object.keys(e).map((i) => e[i]);
    }

    parameterTypeChanged() {
        let value: number = 0;

        if (this.editable.checked)
            value += this.editable.value;
        if (this.static.checked)
            value += this.static.value;
        if (this.calculable.checked)
            value += this.calculable.value;
        if (this.visible.checked)
            value += +this.visible.value;
        if (this.important.checked)
            value += +this.important.value;
        if (this.optional.checked)
            value += +this.optional.value;

        this.parameterContext.setValue(value);
        console.log(this.parameterContext.value);
    }

    private setParameterType() {
        let value: number = this.parameterContext.value;

        if (value >= this.context.optional) {
            value -= this.context.optional;
            this.optional.checked = true;
        }
        if (value >= this.context.important) {
            value -= this.context.important;
            this.important.checked = true;
        }
        if (value >= this.context.staticData) {
            value -= this.context.staticData;
            this.static.checked = true;
        }
        if (value >= this.context.calculation) {
            value -= this.context.calculation;
            this.calculable.checked = true;
        }
        if (value >= this.context.editable) {
            value -= this.context.editable;
            this.editable.checked = true;
        }
        if (value >= this.context.visible) {
            value -= this.context.visible;
            this.visible.checked = true;
        }
    }


    addValueOption() {
        let valueOption = new ValueOptionImpl();
        if (this.newParameter.valueOptions.length > 0)
            valueOption.id = Math.max.apply(Math, this.newParameter.valueOptions.map(function (vo) { return vo.id })) + 1;
        else
            valueOption.id = 0;
        this.newParameter.valueOptions.push(valueOption);
    }

    removeValueOption(valueOption: ValueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(vo => vo !== valueOption);

        if (this.newParameter.valueOptions.length == 0) {
            this.allowUserValues = false;
            this.onAllowUserValues();
        }
    }

    select(parameter: Parameter) {
        let position = this.value.nativeElement.selectionEnd;

        if (position >= 0) {
            let value = this.parameterValue.value as string;
            this.parameterValue.setValue(
                value.slice(0, position) + `[${parameter.name}]` + value.slice(position));
            this.value.nativeElement.focus();
            this.value.nativeElement.selectionEnd = position + `[${parameter.name}]`.length;
        }
        else {
            this.parameterValue.setValue(`${this.parameterValue.value}[${parameter.name}]`);
            this.value.nativeElement.focus();
            this.value.nativeElement.selectionEnd = this.parameterValue.value.length;
        }
    }

    allowUserValues = false;

    onAllowUserValues() {
        this.newParameter.valueOptionSetting =
            this.allowUserValues ? ValueOptionSettings.UserInput : ValueOptionSettings.None;
    }

    onSubmit($event) {
        if (this.newlyAddedParameter)
            this.create();
        else
            this.update();
    }

    private create() {
        this.created.emit(this.parameterForm.value);
    }

    private update() {
        this.parameterService.update(this.scriptId, this.parameterForm.value)
            .subscribe(() => {
                this.updated.emit(this.parameterForm.value);
            },
                error => console.error(error));
    }

    private setValueOptionsSettings() {
        this.allowUserValues = this.newParameter.valueOptionSetting == ValueOptionSettings.UserInput;
    }

    private getStyledValue() : string {
        let styledValue = "";
        let parameter = "";
        let insideParameter = false;
        let index = 0;
        for (var i = 0; i < this.parameterValue.value.length; i++) {
            if (insideParameter && this.parameterValue.value[i] == "]") {
                styledValue += `<span style="color:red">${parameter}</span>`;
                parameter = "";
                insideParameter = false;
                continue;
            }
            else if (this.parameterValue.value[i] == "[") {
                insideParameter = true;
                continue;
            }
            else if (insideParameter) {
                parameter += this.parameterValue.value[i];
                continue;
            }


            if (this.parameterValue.value[i] == "(")
                styledValue += `<span style="color:${this.colors[index++]}">(</span>`;
            else if (this.parameterValue.value[i] == ")")
                styledValue += `<span style="color:${this.colors[--index]}">)</span>`;
            else
                styledValue += this.parameterValue.value[i];
        }

        return styledValue;
    }
}
