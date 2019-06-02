import { Component, Input, SimpleChanges, Output, EventEmitter, SimpleChange, ViewChild } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterImpl } from '../../../../models/parameterImpl';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
import { ValueOption } from '../../../../models/interfaces/valueOption';
import { ValueOptionImpl } from '../../../../models/valueOptionImpl';
import { ParameterFilter } from '../../../../models/enums/parameter-filter';
import { ValueOptionSettings } from '../../../../models/enums/valueOptionSettings';
import { FormGroup, FormControl, Validators, FormArray, AbstractControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { ValueType } from '../../../../models/enums/valueType';
import { EnumObject } from '../../../../models/interfaces/enumObject';
import { MatRadioButton } from '@angular/material/radio';
import { MatCheckbox } from '@angular/material/checkbox';

@Component({
    selector: 'app-data-parameter-form',
    templateUrl: './data-parameter-form.component.html',
    styleUrls: ['./data-parameter-form.component.scss']
})

export class DataParameterFormComponent {
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
        valueOptionSetting: new FormControl('0'),
        valueOptions: new FormArray([])
    });

    matcher = new AppErrorStateMatcher();

    @Input('newlyAddedParameter') newlyAddedParameter: boolean;
    @Input('scriptId') scriptId: number;
    @Input('newParameter') newParameter: Parameter = new ParameterImpl();

    @Output('created') created = new EventEmitter<Parameter>();

   // type: string = ParameterFilter[ParameterFilter.data];
    // important: boolean;

    valueTypes = this.getEnumValues(ValueType);
    context = ParameterOptions;

    @ViewChild('editable') editable: MatRadioButton;
    @ViewChild('static') static: MatRadioButton;
    @ViewChild('calculable') calculable: MatRadioButton;
    @ViewChild('visible') visible: MatCheckbox;
    @ViewChild('important') important: MatCheckbox;
    @ViewChild('optional') optional: MatCheckbox;

    get parameterId(): AbstractControl {
        return this.parameterForm.get('id');
    }
    get parameterName(): AbstractControl {
        return this.parameterForm.get('name');
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

    constructor(private parameterService: ParameterService) {
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes.newParameter) {
            let parameter = changes.newParameter.currentValue as Parameter;
            this.parameterForm.patchValue(parameter);

            parameter.valueOptions.forEach(vo => this.parameterValueOptions.push(new FormGroup({
                id: new FormControl(vo.id),
                name: new FormControl(vo.name),
                value: new FormControl(vo.value),
                description: new FormControl(vo.description)
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

    allowUserValues = false;

    onAllowUserValues() {
        this.newParameter.valueOptionSetting =
            this.allowUserValues ? ValueOptionSettings.UserInput : ValueOptionSettings.None;
    }

    onSubmit($event) {
       // this.adjustProperties();
       // this.setContext();

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
            .subscribe((p: Parameter) => {
                console.log(p);
            },
                error => console.error(error));
    }

    //private setDataType() {
    //    if ((this.newParameter.context & ParameterFilter.data) != 0)
    //        this.type = ParameterFilter[ParameterFilter.data];
    //    else if ((this.newParameter.context & ParameterFilter.static) != 0)
    //        this.type = ParameterFilter[ParameterFilter.static];
    //    else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
    //        this.type = ParameterFilter[ParameterFilter.calculation];
    //}

    private setValueOptionsSettings() {
        this.allowUserValues = this.newParameter.valueOptionSetting == ValueOptionSettings.UserInput;
    }

    //private adjustProperties() {
    //    if (this.type === ParameterFilter[ParameterFilter.static]) {
    //        this.newParameter.dataValidator = null;
    //        this.newParameter.valueOptions = null;
    //    }
    //    else if (this.type === ParameterFilter[ParameterFilter.calculation])
    //        this.newParameter.valueOptions = null;
    //}

    //private setContext() {
    //    if (this.type === ParameterFilter[ParameterFilter.data])
    //        this.setDataContext([ParameterOptions.editable, ParameterOptions.visible]);
    //    else if (this.type === ParameterFilter[ParameterFilter.static])
    //        this.setDataContext([ParameterOptions.staticData]);
    //    else if (this.type === ParameterFilter[ParameterFilter.calculation])
    //        this.setDataContext([ParameterOptions.calculation, ParameterOptions.visible]);
    //}

    //private setDataContext(options: ParameterOptions[]) {
    //    this.newParameter.context = 0;
    //    options.forEach(o => {
    //        if ((this.newParameter.context & o) == 0)
    //            this.newParameter.context += o;
    //    });
    //    if (this.important)
    //        this.newParameter.context += ParameterOptions.important;
    //}
}