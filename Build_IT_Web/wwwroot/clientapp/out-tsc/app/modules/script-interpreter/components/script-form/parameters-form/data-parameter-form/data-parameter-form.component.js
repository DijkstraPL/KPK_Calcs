var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { ParameterImpl } from '../../../../models/parameterImpl';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
import { ValueOptionImpl } from '../../../../models/valueOptionImpl';
import { ValueOptionSettings } from '../../../../models/enums/valueOptionSettings';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { ValueType } from '../../../../models/enums/valueType';
import { MatRadioButton } from '@angular/material/radio';
import { MatCheckbox } from '@angular/material/checkbox';
var DataParameterFormComponent = /** @class */ (function () {
    function DataParameterFormComponent(parameterService) {
        this.parameterService = parameterService;
        this.parameterForm = new FormGroup({
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
        this.matcher = new AppErrorStateMatcher();
        this.newParameter = new ParameterImpl();
        this.created = new EventEmitter();
        // type: string = ParameterFilter[ParameterFilter.data];
        // important: boolean;
        this.valueTypes = this.getEnumValues(ValueType);
        this.context = ParameterOptions;
        this.allowUserValues = false;
    }
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterId", {
        get: function () {
            return this.parameterForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterName", {
        get: function () {
            return this.parameterForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterUnit", {
        get: function () {
            return this.parameterForm.get('unit');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDocument", {
        get: function () {
            return this.parameterForm.get('accordingTo');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterValueType", {
        get: function () {
            return this.parameterForm.get('valueType');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterValue", {
        get: function () {
            return this.parameterForm.get('value');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDescription", {
        get: function () {
            return this.parameterForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterVisibilityValidator", {
        get: function () {
            return this.parameterForm.get('visibilityValidator');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDataValidator", {
        get: function () {
            return this.parameterForm.get('dataValidator');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterContext", {
        get: function () {
            return this.parameterForm.get('context');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterValueOptions", {
        get: function () {
            return this.parameterForm.get('valueOptions');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterGroupName", {
        get: function () {
            return this.parameterForm.get('groupName');
        },
        enumerable: true,
        configurable: true
    });
    DataParameterFormComponent.prototype.ngOnChanges = function (changes) {
        var _this = this;
        if (changes.newParameter) {
            var parameter = changes.newParameter.currentValue;
            this.parameterForm.patchValue(parameter);
            parameter.valueOptions.forEach(function (vo) { return _this.parameterValueOptions.push(new FormGroup({
                id: new FormControl(vo.id),
                name: new FormControl(vo.name),
                value: new FormControl(vo.value),
                description: new FormControl(vo.description)
            })); });
            this.setNewParameterChanges(changes.newParameter);
        }
        if (changes.editMode)
            this.newlyAddedParameter = changes.editMode.currentValue;
    };
    DataParameterFormComponent.prototype.setNewParameterChanges = function (newParameter) {
        console.log('Previous parameter: ', newParameter.previousValue);
        console.log('New parameter: ', newParameter.currentValue);
        this.newParameter = newParameter.currentValue;
        // this.setDataType();
        this.setValueOptionsSettings();
        this.setParameterType();
    };
    DataParameterFormComponent.prototype.getEnumValues = function (e) {
        return Object.keys(e).map(function (i) { return e[i]; });
    };
    DataParameterFormComponent.prototype.parameterTypeChanged = function () {
        var value = 0;
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
    };
    DataParameterFormComponent.prototype.setParameterType = function () {
        var value = this.parameterContext.value;
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
    };
    DataParameterFormComponent.prototype.addValueOption = function () {
        var valueOption = new ValueOptionImpl();
        if (this.newParameter.valueOptions.length > 0)
            valueOption.id = Math.max.apply(Math, this.newParameter.valueOptions.map(function (vo) { return vo.id; })) + 1;
        else
            valueOption.id = 0;
        this.newParameter.valueOptions.push(valueOption);
    };
    DataParameterFormComponent.prototype.removeValueOption = function (valueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
        if (this.newParameter.valueOptions.length == 0) {
            this.allowUserValues = false;
            this.onAllowUserValues();
        }
    };
    DataParameterFormComponent.prototype.onAllowUserValues = function () {
        this.newParameter.valueOptionSetting =
            this.allowUserValues ? ValueOptionSettings.UserInput : ValueOptionSettings.None;
    };
    DataParameterFormComponent.prototype.onSubmit = function ($event) {
        // this.adjustProperties();
        // this.setContext();
        if (this.newlyAddedParameter)
            this.create();
        else
            this.update();
    };
    DataParameterFormComponent.prototype.create = function () {
        this.created.emit(this.parameterForm.value);
    };
    DataParameterFormComponent.prototype.update = function () {
        this.parameterService.update(this.scriptId, this.parameterForm.value)
            .subscribe(function (p) {
            console.log(p);
        }, function (error) { return console.error(error); });
    };
    //private setDataType() {
    //    if ((this.newParameter.context & ParameterFilter.data) != 0)
    //        this.type = ParameterFilter[ParameterFilter.data];
    //    else if ((this.newParameter.context & ParameterFilter.static) != 0)
    //        this.type = ParameterFilter[ParameterFilter.static];
    //    else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
    //        this.type = ParameterFilter[ParameterFilter.calculation];
    //}
    DataParameterFormComponent.prototype.setValueOptionsSettings = function () {
        this.allowUserValues = this.newParameter.valueOptionSetting == ValueOptionSettings.UserInput;
    };
    __decorate([
        Input('newlyAddedParameter'),
        __metadata("design:type", Boolean)
    ], DataParameterFormComponent.prototype, "newlyAddedParameter", void 0);
    __decorate([
        Input('scriptId'),
        __metadata("design:type", Number)
    ], DataParameterFormComponent.prototype, "scriptId", void 0);
    __decorate([
        Input('newParameter'),
        __metadata("design:type", Object)
    ], DataParameterFormComponent.prototype, "newParameter", void 0);
    __decorate([
        Output('created'),
        __metadata("design:type", Object)
    ], DataParameterFormComponent.prototype, "created", void 0);
    __decorate([
        ViewChild('editable'),
        __metadata("design:type", MatRadioButton)
    ], DataParameterFormComponent.prototype, "editable", void 0);
    __decorate([
        ViewChild('static'),
        __metadata("design:type", MatRadioButton)
    ], DataParameterFormComponent.prototype, "static", void 0);
    __decorate([
        ViewChild('calculable'),
        __metadata("design:type", MatRadioButton)
    ], DataParameterFormComponent.prototype, "calculable", void 0);
    __decorate([
        ViewChild('visible'),
        __metadata("design:type", MatCheckbox)
    ], DataParameterFormComponent.prototype, "visible", void 0);
    __decorate([
        ViewChild('important'),
        __metadata("design:type", MatCheckbox)
    ], DataParameterFormComponent.prototype, "important", void 0);
    __decorate([
        ViewChild('optional'),
        __metadata("design:type", MatCheckbox)
    ], DataParameterFormComponent.prototype, "optional", void 0);
    DataParameterFormComponent = __decorate([
        Component({
            selector: 'app-data-parameter-form',
            templateUrl: './data-parameter-form.component.html',
            styleUrls: ['./data-parameter-form.component.scss']
        }),
        __metadata("design:paramtypes", [ParameterService])
    ], DataParameterFormComponent);
    return DataParameterFormComponent;
}());
export { DataParameterFormComponent };
//# sourceMappingURL=data-parameter-form.component.js.map