var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParameterFilter } from '../../../models/enums/parameter-filter';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { moveItemInArray } from '@angular/cdk/drag-drop';
var ParametersFormComponent = /** @class */ (function () {
    function ParametersFormComponent(parameterService, route) {
        this.parameterService = parameterService;
        this.route = route;
        this.newParameter = new ParameterImpl();
        this.editMode = false;
        this.newlyAddedParameter = false;
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
    ParametersFormComponent.prototype.drop = function (event) {
        moveItemInArray(this.filteredParameters, event.previousIndex, event.currentIndex);
        this.setNumbers(event);
        this.saveParameters();
    };
    ParametersFormComponent.prototype.setNumbers = function (event) {
        var sortedParameters = this.sortParameters(this.filteredParameters, 'number');
        var addition = this.getAddition();
        sortedParameters[event.previousIndex].number = event.currentIndex + addition;
        if (event.currentIndex < event.previousIndex) {
            var i = event.previousIndex - 1;
            for (i; i >= event.currentIndex; i--)
                sortedParameters[i].number = sortedParameters[i].number + 1;
        }
        else if (event.currentIndex > event.previousIndex) {
            var i = event.currentIndex;
            for (i; i > event.previousIndex; i--)
                sortedParameters[i].number = sortedParameters[i].number - 1;
        }
    };
    ParametersFormComponent.prototype.getAddition = function () {
        var addition = 0;
        if (this.parametersToShow == 'data')
            addition = 0;
        if (this.parametersToShow == 'static' || this.parametersToShow == 'calculation') {
            var parametersFilterCriteria_1 = ParameterFilter['data'];
            addition += this.parameters.filter(function (p) { return (p.context & parametersFilterCriteria_1) != 0; }).length;
        }
        if (this.parametersToShow == 'calculation') {
            var parametersFilterCriteria_2 = ParameterFilter['static'];
            addition += this.parameters.filter(function (p) { return (p.context & parametersFilterCriteria_2) != 0; }).length;
        }
        return addition;
    };
    ParametersFormComponent.prototype.getParameters = function (id) {
        var _this = this;
        this.parameterService.getParameters(id, "en").subscribe(function (parameters) {
            _this.parameters = parameters;
            _this.onParametersToShowChange();
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
        this.newlyAddedParameter = false;
        this.newParameter = parameter;
    };
    ParametersFormComponent.prototype.remove = function (parameterId) {
        var _this = this;
        if (confirm("Are you sure?")) {
            this.parameterService.delete(this.scriptId, parameterId)
                .subscribe(function () {
                _this.parameters = _this.parameters.filter(function (p) { return p.id != parameterId; });
                _this.onParametersToShowChange();
                _this.refreshNumbering(_this.parameters.find(function (p) { return p.id == parameterId; }).number);
                _this.saveParameters();
            }, function (error) { return console.error(error); });
        }
    };
    ParametersFormComponent.prototype.refreshNumbering = function (number) {
        var index = 0;
        for (var _i = 0, _a = this.sortParameters(this.parameters, 'number'); _i < _a.length; _i++) {
            var parameter = _a[_i];
            parameter.number = index++;
        }
    };
    ParametersFormComponent.prototype.onCreated = function (parameter) {
        var _this = this;
        if (this.parameters.length > 0)
            parameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
        else
            parameter.number = 0;
        this.parameterService.create(this.scriptId, parameter)
            .subscribe(function () {
            _this.getParameters(_this.scriptId);
            _this.editMode = false;
        });
    };
    ParametersFormComponent.prototype.onUpdated = function (parameter) {
        var index = this.parameters.findIndex(function (p) { return p.id == parameter.id; });
        this.parameters[index] = parameter;
        this.editMode = false;
    };
    ParametersFormComponent.prototype.changeEditMode = function () {
        if (this.editMode) {
            this.editMode = false;
            this.newlyAddedParameter = false;
            this.newParameter = null;
        }
    };
    ParametersFormComponent.prototype.sortParameters = function (parameters, prop) {
        if (parameters)
            return parameters.sort(function (a, b) { return a[prop] > b[prop] ? 1 :
                a[prop] === b[prop] ? 0 :
                    -1; });
    };
    ParametersFormComponent.prototype.addNewParameter = function () {
        this.editMode = true;
        this.newlyAddedParameter = true;
        this.newParameter = new ParameterImpl();
        if (this.parameters.length == 0)
            this.newParameter.number = 0;
        else
            this.newParameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
    };
    ParametersFormComponent.prototype.saveParameters = function () {
        var _this = this;
        this.parameters.forEach(function (p) {
            _this.parameterService.update(_this.scriptId, p)
                .subscribe(function () { }, function (error) { return console.error(error); });
        });
    };
    __decorate([
        Input('defaultLanguage'),
        __metadata("design:type", Object)
    ], ParametersFormComponent.prototype, "defaultLanguage", void 0);
    ParametersFormComponent = __decorate([
        Component({
            selector: 'app-parameters-form',
            templateUrl: './parameters-form.component.html',
            styleUrls: ['./parameters-form.component.scss']
        }),
        __metadata("design:paramtypes", [ParameterService,
            ActivatedRoute])
    ], ParametersFormComponent);
    return ParametersFormComponent;
}());
export { ParametersFormComponent };
//# sourceMappingURL=parameters-form.component.js.map