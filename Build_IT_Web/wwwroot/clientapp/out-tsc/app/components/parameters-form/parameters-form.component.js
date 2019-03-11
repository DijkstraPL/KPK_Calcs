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
import { ParameterFilter } from '../../models/enums/parameter-filter';
var ParametersFormComponent = /** @class */ (function () {
    function ParametersFormComponent(parameterService, route) {
        this.parameterService = parameterService;
        this.route = route;
        this.newParameter = new ParameterImpl();
        this.editMode = false;
        this.parametersToShow = "all";
    }
    ParametersFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.scriptId = +params['id'];
        });
        if (isNaN(this.scriptId))
            return;
        this.getParameters(this.scriptId);
    };
    ParametersFormComponent.prototype.getParameters = function (id) {
        var _this = this;
        this.parameterService.getParameters(id).subscribe(function (parameters) {
            _this.parameters = parameters;
            _this.onParametersToShowChange();
            console.log("Parameters", _this.parameters);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.onParametersToShowChange = function () {
        var parametersFilterCriteria = ParameterFilter[this.parametersToShow];
        switch (parametersFilterCriteria) {
            case ParameterFilter.all:
                this.filteredParameters = this.parameters;
                break;
            default:
                this.filteredParameters = this.parameters.filter(function (p) { return (p.context & parametersFilterCriteria) != 0; });
                break;
        }
    };
    ParametersFormComponent.prototype.editParameter = function (parameter) {
        this.editMode = true;
        this.newParameter = parameter;
    };
    ParametersFormComponent.prototype.remove = function (parameterId) {
        var _this = this;
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe(function (p) {
            _this.parameters = _this.parameters.filter(function (p) { return p.id != parameterId; });
            _this.onParametersToShowChange();
            console.log("Parameters", p);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.onCreated = function (parameter) {
        var _this = this;
        if (this.parameters.length > 0)
            parameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
        else
            parameter.number = 0;
        this.parameterService.create(this.scriptId, parameter)
            .subscribe(function (p) {
            console.log(p);
            _this.parameters.push(p);
        });
    };
    ParametersFormComponent.prototype.changeEditMode = function () {
        if (!this.editMode)
            this.newParameter = new ParameterImpl();
    };
    ParametersFormComponent.prototype.sortParameters = function (parameters, prop) {
        if (parameters)
            return parameters.sort(function (a, b) { return a[prop] > b[prop] ? 1 :
                a[prop] === b[prop] ? 0 :
                    -1; });
    };
    ParametersFormComponent.prototype.moveUp = function (parameter) {
        var sortedParameters = this.sortParameters(this.parameters, 'number');
        var currentIndex = sortedParameters.indexOf(parameter);
        if (currentIndex === sortedParameters.length - 1)
            return;
        var tempNumber = parameter.number;
        parameter.number = sortedParameters[currentIndex + 1].number;
        sortedParameters[currentIndex + 1].number = tempNumber;
        this.saveParameters();
    };
    ParametersFormComponent.prototype.moveDown = function (parameter) {
        var sortedParameters = this.sortParameters(this.parameters, 'number');
        var currentIndex = sortedParameters.indexOf(parameter);
        if (currentIndex === 0)
            return;
        var tempNumber = parameter.number;
        parameter.number = sortedParameters[currentIndex - 1].number;
        sortedParameters[currentIndex - 1].number = tempNumber;
        this.saveParameters();
    };
    ParametersFormComponent.prototype.saveParameters = function () {
        var _this = this;
        this.parameters.forEach(function (p) {
            _this.parameterService.update(_this.scriptId, p)
                .subscribe(function (p) {
                console.log(p);
            }, function (error) { return console.error(error); });
        });
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