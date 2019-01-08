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
import { ParameterOptions } from '../../models/parameterOptions';
var ScriptCalculatorComponent = /** @class */ (function () {
    function ScriptCalculatorComponent(scriptService) {
        this.scriptService = scriptService;
        this.scripts = [];
        this.parameterOptions = ParameterOptions;
    }
    ScriptCalculatorComponent.prototype.ngOnInit = function () {
        this.setScript();
    };
    ScriptCalculatorComponent.prototype.setScript = function () {
        var _this = this;
        this.scriptService.getScripts().subscribe(function (scripts) {
            _this.scripts = scripts;
            console.log("Scripts", _this.scripts);
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent.prototype.onChange = function () {
        this.setParameters();
    };
    ScriptCalculatorComponent.prototype.setParameters = function () {
        var _this = this;
        this.scriptService.getParameters(this.selectedScript.id).subscribe(function (parameters) {
            _this.parameters = parameters;
            console.log("Parameters", _this.parameters);
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent.prototype.calculate = function () {
        var _this = this;
        var parameters = "";
        this.parameters.filter(function (parameter) { return (parameter.context & ParameterOptions.Editable) != 0; })
            .forEach(function (parameter) {
            parameters += "[";
            parameters += parameter.name;
            parameters += "]=";
            parameters += parameter.value;
            parameters += "|";
        });
        parameters = parameters.substr(0, parameters.length - 1);
        this.scriptService.calculate(this.selectedScript.name, parameters)
            .subscribe(function (params) {
            _this.resultParameters = params;
            console.log("Results", _this.resultParameters);
        }, function (error) { return console.error(error); });
    };
    ScriptCalculatorComponent = __decorate([
        Component({
            selector: 'app-script-calculator',
            templateUrl: './script-calculator.component.html',
            styleUrls: ['./script-calculator.component.css']
        }),
        __metadata("design:paramtypes", [ScriptService])
    ], ScriptCalculatorComponent);
    return ScriptCalculatorComponent;
}());
export { ScriptCalculatorComponent };
//# sourceMappingURL=script-calculator.component.js.map