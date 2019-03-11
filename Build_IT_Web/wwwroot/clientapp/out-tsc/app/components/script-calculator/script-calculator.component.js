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
var ScriptCalculatorComponent = /** @class */ (function () {
    function ScriptCalculatorComponent(route, scriptService, parameterService, calculationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.parameterOptions = ParameterOptions;
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
                _this.filterParameters(),
                console.log("Parameters", _this.parameters);
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent.prototype.sortParameters = function (parameters, prop) {
        if (parameters)
            return parameters.sort(function (a, b) { return a[prop] > b[prop] ? 1 :
                a[prop] === b[prop] ? 0 :
                    -1; });
    };
    ScriptCalculatorComponent.prototype.setValueChanged = function (parameter) {
        this.valueChanged = true;
        //let index = this.visibleParameters.indexOf(parameter);
        //let properties: { [name: string]: string } = {};
        //for (let i = 0; i <= index; i++) {
        //    properties[`[${this.visibleParameters[i].name}]`] = this.visibleParameters[i].value;
        //}
        //for (let i = index + 1; i < this.visibleParameters.length; i++) {
        //    if (!this.visibleParameters[i].dataValidator)
        //        continue;
        //    let dataValidator = this.visibleParameters[i].dataValidator.slice(
        //        this.visibleParameters[i].dataValidator.indexOf('(') + 1,
        //        this.visibleParameters[i].dataValidator.length - 1)
        //    properties.forEach(p => {
        //       dataValidator.replace(p.name, p.value);
        //    });
        //}
    };
    ScriptCalculatorComponent.prototype.filterParameters = function () {
        this.visibleParameters = this.parameters.filter(function (p) { return (p.context & ParameterOptions.Visible) != 0; });
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