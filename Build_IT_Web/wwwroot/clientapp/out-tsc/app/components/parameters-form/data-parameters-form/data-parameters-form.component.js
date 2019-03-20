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
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ParameterOptions } from '../../../models/enums/parameterOptions';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';
import { ParameterFilter } from '../../../models/enums/parameter-filter';
import { ValueOptionSettings } from '../../../models/enums/valueOptionSettings';
var DataParametersFormComponent = /** @class */ (function () {
    function DataParametersFormComponent(parameterService) {
        this.parameterService = parameterService;
        this.newParameter = new ParameterImpl();
        this.created = new EventEmitter();
        this.type = ParameterFilter[ParameterFilter.data];
        this.allowUserValues = false;
    }
    DataParametersFormComponent.prototype.ngOnChanges = function (changes) {
        if (changes.newParameter)
            this.setNewParameterChanges(changes.newParameter);
        if (changes.editMode)
            this.editMode = changes.editMode.currentValue;
    };
    DataParametersFormComponent.prototype.addValueOption = function () {
        var valueOption = new ValueOptionImpl();
        if (this.newParameter.valueOptions.length > 0)
            valueOption.id = Math.max.apply(Math, this.newParameter.valueOptions.map(function (vo) { return vo.id; })) + 1;
        else
            valueOption.id = 0;
        this.newParameter.valueOptions.push(valueOption);
    };
    DataParametersFormComponent.prototype.removeValueOption = function (valueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
        if (this.newParameter.valueOptions.length == 0) {
            this.allowUserValues = false;
            this.onAllowUserValues();
        }
    };
    DataParametersFormComponent.prototype.onAllowUserValues = function () {
        this.newParameter.valueOptionSetting =
            this.allowUserValues ? ValueOptionSettings.UserInput : ValueOptionSettings.None;
    };
    DataParametersFormComponent.prototype.setImportant = function () {
        if ((this.newParameter.context & ParameterOptions.Important) != 0)
            this.important = true;
        else
            this.important = false;
    };
    DataParametersFormComponent.prototype.onSubmit = function ($event) {
        this.adjustProperties();
        this.setContext();
        if (!this.editMode)
            this.create();
        else
            this.update();
    };
    DataParametersFormComponent.prototype.setNewParameterChanges = function (newParameter) {
        console.log('Previous parameter: ', newParameter.previousValue);
        console.log('New parameter: ', newParameter.currentValue);
        this.newParameter = newParameter.currentValue;
        this.setDataType();
        this.setValueOptionsSettings();
        this.setImportant();
    };
    DataParametersFormComponent.prototype.setDataType = function () {
        if ((this.newParameter.context & ParameterFilter.data) != 0)
            this.type = ParameterFilter[ParameterFilter.data];
        else if ((this.newParameter.context & ParameterFilter.static) != 0)
            this.type = ParameterFilter[ParameterFilter.static];
        else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
            this.type = ParameterFilter[ParameterFilter.calculation];
    };
    DataParametersFormComponent.prototype.setValueOptionsSettings = function () {
        this.allowUserValues = this.newParameter.valueOptionSetting == ValueOptionSettings.UserInput;
    };
    DataParametersFormComponent.prototype.adjustProperties = function () {
        if (this.type === ParameterFilter[ParameterFilter.static]) {
            this.newParameter.dataValidator = null;
            this.newParameter.valueOptions = null;
        }
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.newParameter.valueOptions = null;
    };
    DataParametersFormComponent.prototype.setContext = function () {
        if (this.type === ParameterFilter[ParameterFilter.data])
            this.setDataContext([ParameterOptions.Editable, ParameterOptions.Visible]);
        else if (this.type === ParameterFilter[ParameterFilter.static])
            this.setDataContext([ParameterOptions.StaticData]);
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.setDataContext([ParameterOptions.Calculation, ParameterOptions.Visible]);
    };
    DataParametersFormComponent.prototype.setDataContext = function (options) {
        var _this = this;
        this.newParameter.context = 0;
        options.forEach(function (o) {
            if ((_this.newParameter.context & o) == 0)
                _this.newParameter.context += o;
        });
        if (this.important)
            this.newParameter.context += ParameterOptions.Important;
    };
    DataParametersFormComponent.prototype.create = function () {
        this.created.emit(this.newParameter);
    };
    DataParametersFormComponent.prototype.update = function () {
        this.parameterService.update(this.scriptId, this.newParameter)
            .subscribe(function (p) {
            console.log(p);
        }, function (error) { return console.error(error); });
    };
    __decorate([
        Input('editMode'),
        __metadata("design:type", Boolean)
    ], DataParametersFormComponent.prototype, "editMode", void 0);
    __decorate([
        Input('scriptId'),
        __metadata("design:type", Number)
    ], DataParametersFormComponent.prototype, "scriptId", void 0);
    __decorate([
        Input('newParameter'),
        __metadata("design:type", Object)
    ], DataParametersFormComponent.prototype, "newParameter", void 0);
    __decorate([
        Output('created'),
        __metadata("design:type", Object)
    ], DataParametersFormComponent.prototype, "created", void 0);
    DataParametersFormComponent = __decorate([
        Component({
            selector: 'app-data-parameters-form',
            templateUrl: './data-parameters-form.component.html',
            styleUrls: ['./data-parameters-form.component.css']
        }),
        __metadata("design:paramtypes", [ParameterService])
    ], DataParametersFormComponent);
    return DataParametersFormComponent;
}());
export { DataParametersFormComponent };
//# sourceMappingURL=data-parameters-form.component.js.map