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
import { ActivatedRoute } from '@angular/router';
import { ParameterImpl } from '../../models/parameterImpl';
import { ParameterService } from '../../services/parameter.service';
import { ParameterOptions } from '../../models/parameterOptions';
import { ValueOptionImpl } from '../../models/valueOptionImpl';
var ParametersFormComponent = /** @class */ (function () {
    function ParametersFormComponent(parameterService, route) {
        this.parameterService = parameterService;
        this.route = route;
        this.dataParameter = new ParameterImpl();
        this.staticParameter = new ParameterImpl();
        this.calculationParameter = new ParameterImpl();
        this.editMode = false;
    }
    ParametersFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.snapshot.params.subscribe(function (params) {
            _this.scriptId = +params['id'];
        });
        if (isNaN(this.scriptId)) {
            return;
        }
        this.getParameters(this.scriptId);
    };
    ParametersFormComponent.prototype.getParameters = function (id) {
        var _this = this;
        this.parameterService.getParameters(id).subscribe(function (parameters) {
            _this.dataParameters = parameters.filter(function (p) { return (p.context & 2) != 0; });
            _this.staticParameters = parameters.filter(function (p) { return (p.context & 8) != 0; });
            _this.calculationParameters = parameters.filter(function (p) { return (p.context & 4) != 0; }),
                console.log("Data parameters", _this.dataParameters);
            console.log("Static parameters", _this.staticParameters);
            console.log("Calculation parameters", _this.calculationParameters);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.onSubmitDataParameter = function () {
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
    ParametersFormComponent.prototype.onSubmitStaticDataParameter = function () {
        var _this = this;
        var maxNumber = Math.max.apply(Math, this.staticParameters.map(function (dp) { return dp.number; }));
        if (maxNumber < 800)
            maxNumber = 800;
        this.staticParameter.number = ++maxNumber;
        this.staticParameter.context = ParameterOptions.StaticData;
        this.parameterService.create(this.scriptId, this.staticParameter)
            .subscribe(function (p) {
            console.log(p);
            _this.staticParameters.push(p);
        });
    };
    ParametersFormComponent.prototype.onSubmitCalculationParameter = function () {
        var _this = this;
        var maxNumber = Math.max.apply(Math, this.calculationParameters.map(function (dp) { return dp.number; }));
        if (maxNumber < 1000)
            maxNumber = 1000;
        this.calculationParameter.number = ++maxNumber;
        this.calculationParameter.context = ParameterOptions.Calculation | ParameterOptions.Visible;
        this.parameterService.create(this.scriptId, this.calculationParameter)
            .subscribe(function (p) {
            console.log(p);
            _this.calculationParameters.push(p);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.edit = function (parameter) {
        this.parameterService.update(this.scriptId, parameter)
            .subscribe(function (p) {
            console.log(p);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.remove = function (parameterId) {
        var _this = this;
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe(function (p) {
            console.log("Parameters", p),
                _this.dataParameters = _this.dataParameters.filter(function (p) { return p.id != parameterId; }),
                _this.staticParameters = _this.staticParameters.filter(function (p) { return p.id != parameterId; }),
                _this.calculationParameters = _this.calculationParameters.filter(function (p) { return p.id != parameterId; });
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.editDataParameter = function (parameter) {
        this.editMode = true;
        this.dataParameter = parameter;
    };
    ParametersFormComponent.prototype.editStaticParameter = function (parameter) {
        this.editMode = true;
        this.staticParameter = parameter;
    };
    ParametersFormComponent.prototype.editCalculationParameter = function (parameter) {
        this.editMode = true;
        this.calculationParameter = parameter;
    };
    ParametersFormComponent.prototype.addValueOption = function () {
        this.dataParameter.valueOptions.push(new ValueOptionImpl());
    };
    ParametersFormComponent.prototype.removeValueOption = function (valueOption) {
        this.dataParameter.valueOptions =
            this.dataParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
    };
    ParametersFormComponent = __decorate([
        Component({
            selector: 'app-parameters-form',
            templateUrl: './parameters-form.component.html',
            styleUrls: ['./parameters-form.component.css']
        })
        /** parameters-form component*/
        ,
        __metadata("design:paramtypes", [ParameterService,
            ActivatedRoute])
    ], ParametersFormComponent);
    return ParametersFormComponent;
}());
export { ParametersFormComponent };
//# sourceMappingURL=parameters-form.component.js.map