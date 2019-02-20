var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ParameterOptions } from '../../../models/parameterOptions';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';
var DataParametersFormComponent = /** @class */ (function () {
    function DataParametersFormComponent(parameterService) {
        this.parameterService = parameterService;
        this.dataParameter = new ParameterImpl();
    }
    DataParametersFormComponent.prototype.getParameters = function (id) {
        var _this = this;
        this.parameterService.getParameters(id).subscribe(function (parameters) {
            _this.dataParameters = parameters.filter(function (p) { return (p.context & 2) != 0; });
            console.log("Data parameters", _this.dataParameters);
        }, function (error) { return console.error(error); });
    };
    DataParametersFormComponent.prototype.onSubmitDataParameter = function () {
        var _this = this;
        var maxNumber = Math.max.apply(Math, this.dataParameters.map(function (dp) { return dp.number; }));
        if (maxNumber < 0)
            maxNumber = 0;
        this.dataParameter.number = ++maxNumber;
        this.dataParameter.context = ParameterOptions.Editable | ParameterOptions.Visible;
        this.parameterService.create(this.scriptId, this.dataParameter)
            .subscribe(function (p) {
            console.log(p);
            _this.dataParameters.push(p);
        });
    };
    DataParametersFormComponent.prototype.remove = function (parameterId) {
        var _this = this;
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe(function (p) {
            console.log("Parameters", p),
                _this.dataParameters = _this.dataParameters.filter(function (p) { return p.id != parameterId; });
        }, function (error) { return console.error(error); });
    };
    DataParametersFormComponent.prototype.editDataParameter = function (parameter) {
        this.editMode = true;
        this.dataParameter = parameter;
    };
    DataParametersFormComponent.prototype.addValueOption = function () {
        this.dataParameter.valueOptions.push(new ValueOptionImpl());
    };
    DataParametersFormComponent.prototype.removeValueOption = function (valueOption) {
        this.dataParameter.valueOptions =
            this.dataParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
    };
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