var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ParameterImpl } from '../../../../models/parameterImpl';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
import { ValueOptionImpl } from '../../../../models/valueOptionImpl';
import { ParameterFilter } from '../../../../models/enums/parameter-filter';
import { ValueOptionSettings } from '../../../../models/enums/valueOptionSettings';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { ValueType } from '../../../../models/enums/valueType';
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
            context: new FormControl('', Validators.required),
            groupName: new FormControl('', Validators.maxLength(200)),
            accordingTo: new FormControl('', Validators.maxLength(200)),
            notes: new FormControl('', Validators.maxLength(1000)),
            valueOptionSetting: new FormControl(''),
            valueOptions: new FormArray([])
        });
        this.matcher = new AppErrorStateMatcher();
        this.newParameter = new ParameterImpl();
        this.created = new EventEmitter();
        this.type = ParameterFilter[ParameterFilter.data];
        this.allowUserValues = false;
        this.valueTypes = getEnumValues(ValueType);
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
    Object.defineProperty(DataParameterFormComponent.prototype, "parameterDescription", {
        get: function () {
            return this.parameterForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    DataParameterFormComponent.prototype.ngOnChanges = function (changes) {
        if (changes.newParameter) {
            console.log(changes);
            this.parameterForm.patchValue(changes.newParameter.currentValue);
        }
        if (changes.newParameter)
            this.setNewParameterChanges(changes.newParameter);
        if (changes.editMode)
            this.editMode = changes.editMode.currentValue;
    };
    DataParameterFormComponent.prototype.getEnumValues = function (e) {
        return Object.keys(e).map(function (i) { return e[i].toUpperCase(); });
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
    DataParameterFormComponent.prototype.setImportant = function () {
        if ((this.newParameter.context & ParameterOptions.Important) != 0)
            this.important = true;
        else
            this.important = false;
    };
    DataParameterFormComponent.prototype.onSubmit = function ($event) {
        this.adjustProperties();
        this.setContext();
        if (!this.editMode)
            this.create();
        else
            this.update();
    };
    DataParameterFormComponent.prototype.setNewParameterChanges = function (newParameter) {
        console.log('Previous parameter: ', newParameter.previousValue);
        console.log('New parameter: ', newParameter.currentValue);
        this.newParameter = newParameter.currentValue;
        this.setDataType();
        this.setValueOptionsSettings();
        this.setImportant();
    };
    DataParameterFormComponent.prototype.setDataType = function () {
        if ((this.newParameter.context & ParameterFilter.data) != 0)
            this.type = ParameterFilter[ParameterFilter.data];
        else if ((this.newParameter.context & ParameterFilter.static) != 0)
            this.type = ParameterFilter[ParameterFilter.static];
        else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
            this.type = ParameterFilter[ParameterFilter.calculation];
    };
    DataParameterFormComponent.prototype.setValueOptionsSettings = function () {
        this.allowUserValues = this.newParameter.valueOptionSetting == ValueOptionSettings.UserInput;
    };
    DataParameterFormComponent.prototype.adjustProperties = function () {
        if (this.type === ParameterFilter[ParameterFilter.static]) {
            this.newParameter.dataValidator = null;
            this.newParameter.valueOptions = null;
        }
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.newParameter.valueOptions = null;
    };
    DataParameterFormComponent.prototype.setContext = function () {
        if (this.type === ParameterFilter[ParameterFilter.data])
            this.setDataContext([ParameterOptions.Editable, ParameterOptions.Visible]);
        else if (this.type === ParameterFilter[ParameterFilter.static])
            this.setDataContext([ParameterOptions.StaticData]);
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.setDataContext([ParameterOptions.Calculation, ParameterOptions.Visible]);
    };
    DataParameterFormComponent.prototype.setDataContext = function (options) {
        var _this = this;
        this.newParameter.context = 0;
        options.forEach(function (o) {
            if ((_this.newParameter.context & o) == 0)
                _this.newParameter.context += o;
        });
        if (this.important)
            this.newParameter.context += ParameterOptions.Important;
    };
    DataParameterFormComponent.prototype.create = function () {
        this.created.emit(this.newParameter);
    };
    DataParameterFormComponent.prototype.update = function () {
        this.parameterService.update(this.scriptId, this.newParameter)
            .subscribe(function (p) {
            console.log(p);
        }, function (error) { return console.error(error); });
    };
    __decorate([
        Input('editMode'),
        __metadata("design:type", Boolean)
    ], DataParameterFormComponent.prototype, "editMode", void 0);
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