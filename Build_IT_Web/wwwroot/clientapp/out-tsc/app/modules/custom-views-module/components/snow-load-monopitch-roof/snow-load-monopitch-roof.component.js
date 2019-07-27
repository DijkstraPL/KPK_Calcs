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
import { ScriptService } from '../../../script-interpreter/services/script.service';
import { ParameterService } from '../../../script-interpreter/services/parameter.service';
import { CalculationService } from '../../../script-interpreter/services/calculation.service';
import { TranslationService } from '../../../../services/translation.service';
import { ParameterOptions } from '../../../script-interpreter/models/enums/parameterOptions';
var ScriptId = 10;
var SnowLoadMonopitchRoofComponent = /** @class */ (function () {
    function SnowLoadMonopitchRoofComponent(route, scriptService, parameterService, calculationService, translationService) {
        this.route = route;
        this.scriptService = scriptService;
        this.parameterService = parameterService;
        this.calculationService = calculationService;
        this.translationService = translationService;
        this.addition = 0;
        this.resultParameters = [];
        this.parameterOptions = ParameterOptions;
        this.offset = 80;
    }
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "snowFences", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "SnowFences"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "slope", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "α"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "altitude", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "A"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "zone", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "Zone"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "topography", {
        get: function () {
            return this.parameters.find(function (p) { return p.name == "Topography"; });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(SnowLoadMonopitchRoofComponent.prototype, "snowLoad", {
        get: function () {
            return this.resultParameters.find(function (p) { return p.name == "s"; });
        },
        enumerable: true,
        configurable: true
    });
    SnowLoadMonopitchRoofComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.getScript();
        this.getParameters();
        this.translationService.languageChanged$.subscribe(function (language) {
            _this.getScript();
            _this.getParameters();
        });
    };
    SnowLoadMonopitchRoofComponent.prototype.getScript = function () {
        var _this = this;
        this.scriptService.getScript(ScriptId).subscribe(function (script) {
            _this.script = script;
        }, function (error) { return console.error(error); });
    };
    SnowLoadMonopitchRoofComponent.prototype.getParameters = function () {
        var _this = this;
        this.parameterService.getParameters(ScriptId, this.translationService.getCurrentLanguage())
            .subscribe(function (parameters) {
            _this.parameters = parameters.filter(function (p) { return (p.context & ParameterOptions.editable) != 0; });
        }, function (error) { return console.error(error); });
    };
    SnowLoadMonopitchRoofComponent.prototype.onSlopeChange = function () {
        this.setAddition();
        this.calculate();
    };
    SnowLoadMonopitchRoofComponent.prototype.setAddition = function () {
        this.addition = Math.min(Math.tan(+this.slope.value * Math.PI / 180) * 300 / 5, 175);
    };
    SnowLoadMonopitchRoofComponent.prototype.isRequired = function (parameter) {
        return (parameter.context & this.parameterOptions.optional) == 0;
    };
    SnowLoadMonopitchRoofComponent.prototype.calculate = function () {
        var _this = this;
        this.calculationService.calculate(ScriptId, this.parameters)
            .subscribe(function (parameters) {
            _this.resultParameters = parameters;
        }, function (error) { return console.error(error); });
    };
    SnowLoadMonopitchRoofComponent.prototype.onMouseOver = function ($event) {
        $event.srcElement.style.fill = "white";
        $event.srcElement.style.backgroundColor = "white";
        $event.srcElement.style.opacity = "0.3";
    };
    SnowLoadMonopitchRoofComponent.prototype.selectZone = function (zoneNumber) {
        if (zoneNumber == 1)
            this.zone.value = "FirstZone";
        else if (zoneNumber == 2)
            this.zone.value = "SecondZone";
        else if (zoneNumber == 3)
            this.zone.value = "ThirdZone";
        else if (zoneNumber == 4)
            this.zone.value = "FourthZone";
        else if (zoneNumber == 5)
            this.zone.value = "FifthZone";
    };
    SnowLoadMonopitchRoofComponent = __decorate([
        Component({
            selector: 'snow-load-monopitch-roof',
            templateUrl: './snow-load-monopitch-roof.component.html',
            styleUrls: ['./snow-load-monopitch-roof.component.scss']
        }),
        __metadata("design:paramtypes", [ActivatedRoute,
            ScriptService,
            ParameterService,
            CalculationService,
            TranslationService])
    ], SnowLoadMonopitchRoofComponent);
    return SnowLoadMonopitchRoofComponent;
}());
export { SnowLoadMonopitchRoofComponent };
//# sourceMappingURL=snow-load-monopitch-roof.component.js.map