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
import { ScriptService } from '../../services/script.service';
import { ParameterOptions } from '../../models/enums/parameterOptions';
import { ActivatedRoute } from '@angular/router';
import { ParameterService } from '../../services/parameter.service';
import { CalculationService } from '../../services/calculation.service';
import { ValueType } from '../../models/enums/valueType';
import { ValueOptionSettings } from '../../models/enums/valueOptionSettings';
var ScriptCalculatorComponent = /** @class */ (function () {
    function ScriptCalculatorComponent(route, scriptService, parameterService, calculationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.parameterOptions = ParameterOptions;
        this.valueOptionSetting = ValueOptionSettings;
    }
    ScriptCalculatorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (id != undefined) {
            this.scriptService.getScript(id).subscribe(function (script) {
                _this.script = script;
                console.log("Script", _this.script);
                _this.setParameters();
            }, function (error) { return console.error(error); });
        }
        sub.unsubscribe();
    };
    ScriptCalculatorComponent.prototype.setParameters = function () {
        var _this = this;
        this.parameterService.getParameters(this.script.id).subscribe(function (parameters) {
            _this.parameters = parameters.filter(function (p) { return (p.context & ParameterOptions.Editable) != 0; }),
                _this.parameters.forEach(function (p) { return _this.prepareParameter(p); }),
                _this.filterParameters(),
                console.log("Parameters", _this.parameters);
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent.prototype.prepareParameter = function (parameter) {
        parameter.equation = parameter.value;
    };
    ScriptCalculatorComponent.prototype.sortParameters = function (parameters, prop) {
        if (parameters)
            return parameters.sort(function (a, b) { return a[prop] > b[prop] ? 1 :
                a[prop] === b[prop] ? 0 :
                    -1; });
    };
    ScriptCalculatorComponent.prototype.setValueChanged = function (parameter) {
        this.valueChanged = true;
        this.filterParameters();
    };
    ScriptCalculatorComponent.prototype.filterParameters = function () {
        var _this = this;
        this.visibleParameters = this.parameters.filter(function (p) { return (p.context & ParameterOptions.Visible) != 0 && _this.validateVisibility(p); });
    };
    ScriptCalculatorComponent.prototype.calculate = function () {
        var _this = this;
        this.calculationService.calculate(this.script.id, this.parameters)
            .subscribe(function (params) {
            _this.resultParameters = params;
            console.log("Results", _this.resultParameters);
        }, function (error) { return console.error(error); });
        this.valueChanged = false;
    };
    ScriptCalculatorComponent.prototype.validateVisibility = function (parameter) {
        if (!parameter.visibilityValidator)
            return true;
        var visibilityValidatorEquation = parameter.visibilityValidator.slice(parameter.visibilityValidator.indexOf('(') + 1, parameter.visibilityValidator.lastIndexOf(')'));
        this.parameters.forEach(function (p) {
            var value = p.valueType == ValueType.number ? p.value : "'" + p.value + "'";
            visibilityValidatorEquation = visibilityValidatorEquation.replace("[" + p.name + "]", value);
        });
        try {
            var result = eval(visibilityValidatorEquation);
            if (result != null && !result && parameter.value != parameter.equation)
                parameter.value = parameter.equation;
            if (result != null)
                return result;
            else
                return true;
        }
        catch (e) {
            return true;
        }
    };
    ScriptCalculatorComponent = __decorate([
        Component({
            selector: 'app-script-calculator',
            templateUrl: './script-calculator.component.html',
            styleUrls: ['./script-calculator.component.css']
        }),
        __metadata("design:paramtypes", [ActivatedRoute,
            ScriptService,
            ParameterService,
            CalculationService])
    ], ScriptCalculatorComponent);
    return ScriptCalculatorComponent;
}());
export { ScriptCalculatorComponent };
//# sourceMappingURL=script-calculator.component.js.map