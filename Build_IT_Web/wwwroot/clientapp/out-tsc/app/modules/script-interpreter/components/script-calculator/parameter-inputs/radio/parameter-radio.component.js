var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, EventEmitter, Output, Input } from '@angular/core';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
var ParameterRadioComponent = /** @class */ (function () {
    function ParameterRadioComponent() {
        this.parameter = null;
        this.valueChanged = new EventEmitter();
        this.parameterOptions = ParameterOptions;
    }
    ParameterRadioComponent.prototype.ngOnInit = function () {
    };
    ParameterRadioComponent.prototype.changeValue = function (event) {
        this.parameter.value = event.value;
        this.valueChanged.emit(this.parameter);
    };
    ParameterRadioComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterRadioComponent.prototype, "parameter", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterRadioComponent.prototype, "valueChanged", void 0);
    ParameterRadioComponent = __decorate([
        Component({
            selector: 'parameter-radio',
            templateUrl: './parameter-radio.component.html',
            styleUrls: ['./parameter-radio.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterRadioComponent);
    return ParameterRadioComponent;
}());
export { ParameterRadioComponent };
//# sourceMappingURL=parameter-radio.component.js.map