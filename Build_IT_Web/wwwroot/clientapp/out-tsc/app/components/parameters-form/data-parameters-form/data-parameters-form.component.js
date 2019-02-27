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
var DataParametersFormComponent = /** @class */ (function () {
    function DataParametersFormComponent(parameterService) {
        this.parameterService = parameterService;
        this.newParameter = new ParameterImpl();
        this.created = new EventEmitter();
        this.type = ParameterFilter[ParameterFilter.data];
    }
    DataParametersFormComponent.prototype.ngOnChanges = function (changes) {
        if (changes.newParameter) {
            var newParameter = changes.newParameter;
            console.log('Previous parameter: ', newParameter.previousValue);
            console.log('New parameter: ', newParameter.currentValue);
            this.newParameter = newParameter.currentValue;
            this.setDataType();
        }
        if (changes.editMode)
            this.editMode = changes.editMode.currentValue;
    };
    DataParametersFormComponent.prototype.addValueOption = function () {
        this.newParameter.valueOptions.push(new ValueOptionImpl());
    };
    DataParametersFormComponent.prototype.removeValueOption = function (valueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
    };
    DataParametersFormComponent.prototype.onSubmit = function () {
        this.adjustProperties();
        this.setContext();
        if (!this.editMode)
            this.create();
        else
            this.update();
    };
    DataParametersFormComponent.prototype.setDataType = function () {
        if ((this.newParameter.context & ParameterFilter.data) != 0)
            this.type = ParameterFilter[ParameterFilter.data];
        else if ((this.newParameter.context & ParameterFilter.static) != 0)
            this.type = ParameterFilter[ParameterFilter.static];
        else if ((this.newParameter.context & ParameterFilter.calculation) != 0)
            this.type = ParameterFilter[ParameterFilter.calculation];
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
            this.newParameter.context = ParameterOptions.Editable | ParameterOptions.Visible;
        else if (this.type === ParameterFilter[ParameterFilter.static])
            this.newParameter.context = ParameterOptions.StaticData;
        else if (this.type === ParameterFilter[ParameterFilter.calculation])
            this.newParameter.context = ParameterOptions.Calculation | ParameterOptions.Visible;
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
        Input(),
        __metadata("design:type", Boolean)
    ], DataParametersFormComponent.prototype, "editMode", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Number)
    ], DataParametersFormComponent.prototype, "scriptId", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], DataParametersFormComponent.prototype, "newParameter", void 0);
    __decorate([
        Output(),
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