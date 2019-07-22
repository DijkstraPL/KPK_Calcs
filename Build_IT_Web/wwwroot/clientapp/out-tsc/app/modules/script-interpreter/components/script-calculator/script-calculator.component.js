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
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ParameterOptions } from '../../models/enums/parameterOptions';
import { ValueType } from '../../models/enums/valueType';
import { ParametersGroup } from '../../models/parametersGroup';
import { CalculationService } from '../../services/calculation.service';
import { ParameterService } from '../../services/parameter.service';
import { ScriptService } from '../../services/script.service';
import { TranslationService } from '../../../../services/translation.service';
var ScriptCalculatorComponent = /** @class */ (function () {
    function ScriptCalculatorComponent(route, scriptService, parameterService, calculationService, translationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.translationService = translationService;
        this.myControl = new FormControl();
        this.parameterOptions = ParameterOptions;
    }
    ScriptCalculatorComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (id != undefined)
            this.getScript(id);
        sub.unsubscribe();
        this.translationService.languageChanged$.subscribe(function (language) {
            if (id != undefined)
                _this.getScript(id, language);
        });
    };
    ScriptCalculatorComponent.prototype.getScript = function (id, language) {
        var _this = this;
        this.scriptService.getScript(id).subscribe(function (script) {
            _this.script = script;
            console.log("Script", _this.script);
            _this.setParameters();
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent.prototype.setParameters = function () {
        var _this = this;
        this.parameterService.getParameters(this.script.id).subscribe(function (parameters) {
            _this.parameters = parameters.filter(function (p) { return (p.context & ParameterOptions.editable) != 0; }),
                _this.staticDataParameters = parameters.filter(function (p) {
                    return (p.context & ParameterOptions.staticData) != 0 &&
                        (p.context & ParameterOptions.visible) != 0;
                }),
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
    ScriptCalculatorComponent.prototype.onValueChanged = function (parameter) {
        this.valueChanged = true;
        this.filterParameters();
    };
    ScriptCalculatorComponent.prototype.filterParameters = function () {
        var _this = this;
        this.visibleParameters = this.parameters.filter(function (p) {
            return (p.context & ParameterOptions.visible) != 0 &&
                _this.validateVisibility(p);
        });
        if (this.groups == undefined)
            this.createGroups();
        this.populateGroups();
    };
    ScriptCalculatorComponent.prototype.createGroups = function () {
        var groupNames = this.visibleParameters.map(function (vp) { return vp.groupName; })
            .filter(function (value, index, self) { return self.indexOf(value) === index &&
            value != "" && value != undefined; });
        this.groups = groupNames.map(function (gn) { return new ParametersGroup(gn); });
    };
    ScriptCalculatorComponent.prototype.populateGroups = function () {
        var _this = this;
        this.groups.forEach(function (g) { return g.clear(); });
        this.notGroupedParameters = [];
        this.visibleParameters.forEach(function (vp) {
            if (vp.groupName == "" || vp.groupName == undefined)
                _this.notGroupedParameters.push(vp);
            else {
                var group = _this.groups.find(function (g) { return g.name === vp.groupName; });
                group.addParameter(vp);
            }
        });
    };
    ScriptCalculatorComponent.prototype.isValid = function () {
        var _this = this;
        return this.parameters
            .filter(function (p) { return (p.context & ParameterOptions.editable) != 0 &&
            (p.context & ParameterOptions.optional) == 0 &&
            _this.validateVisibility(p); })
            .every(function (p) { return p.value != undefined && p.value != ""; });
    };
    ScriptCalculatorComponent.prototype.calculate = function () {
        var _this = this;
        this.isCalculating = true;
        this.calculationService.calculate(this.script.id, this.parameters)
            .subscribe(function (params) {
            _this.resultParameters = params.filter(function (p) { return (p.context & ParameterOptions.visible) != 0; });
            _this.resultParameters.forEach(function (p) { return p.equation = _this.setEquation(p); });
        }, function (error) {
            console.error(error);
            _this.isCalculating = false;
        }, function () {
            _this.isCalculating = false;
            _this.valueChanged = false;
        });
    };
    ScriptCalculatorComponent.prototype.setEquation = function (parameter) {
        var firstPartOfEquation = parameter.equation.replace(/\[/g, '').replace(/\]/g, '');
        var secondPartOfEquation = parameter.equation;
        this.parameters.concat(this.staticDataParameters).concat(this.resultParameters).forEach(function (p) {
            secondPartOfEquation = secondPartOfEquation.replace("[" + p.name + "]", " " + p.value + p.unit + " ");
        });
        return firstPartOfEquation + ' = ' + secondPartOfEquation;
    };
    ScriptCalculatorComponent.prototype.validateVisibility = function (parameter) {
        if (!parameter.visibilityValidator)
            return true;
        var visibilityValidatorEquation = parameter.visibilityValidator.slice(parameter.visibilityValidator.indexOf('(') + 1, parameter.visibilityValidator.lastIndexOf(')'));
        this.parameters.forEach(function (p) {
            var value = p.valueType == ValueType.number ? p.value : "'" + p.value + "'";
            visibilityValidatorEquation = visibilityValidatorEquation.split("[" + p.name + "]").join(value);
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
            selector: 'script-calculator',
            templateUrl: './script-calculator.component.html',
            styleUrls: ['./script-calculator.component.scss']
        }),
        __metadata("design:paramtypes", [ActivatedRoute,
            ScriptService,
            ParameterService,
            CalculationService,
            TranslationService])
    ], ScriptCalculatorComponent);
    return ScriptCalculatorComponent;
}());
export { ScriptCalculatorComponent };
//# sourceMappingURL=script-calculator.component.js.map