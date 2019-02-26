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
        if (isNaN(this.scriptId)) {
            return;
        }
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
    ParametersFormComponent.prototype.remove = function (parameterId) {
        var _this = this;
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe(function (p) {
            _this.parameters = _this.parameters.filter(function (p) { return p.id != parameterId; });
            _this.onParametersToShowChange();
            console.log("Parameters", p);
        }, function (error) { return console.error(error); });
    };
    ParametersFormComponent.prototype.editParameter = function (parameter) {
        this.editMode = true;
        this.newParameter = parameter;
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