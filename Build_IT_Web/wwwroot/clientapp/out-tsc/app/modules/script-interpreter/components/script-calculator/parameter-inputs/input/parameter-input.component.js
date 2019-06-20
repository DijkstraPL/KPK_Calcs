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
import { ValueType } from '../../../../models/enums/valueType';
var ParameterInputComponent = /** @class */ (function () {
    function ParameterInputComponent() {
        this.parameter = null;
        this.valueChanged = new EventEmitter();
        this.parameterOptions = ParameterOptions;
        this.valueTypes = ValueType;
    }
    ParameterInputComponent.prototype.ngOnInit = function () {
    };
    ParameterInputComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    ParameterInputComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterInputComponent.prototype, "parameter", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterInputComponent.prototype, "valueChanged", void 0);
    ParameterInputComponent = __decorate([
        Component({
            selector: 'parameter-input',
            templateUrl: './parameter-input.component.html',
            styleUrls: ['./parameter-input.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterInputComponent);
    return ParameterInputComponent;
}());
export { ParameterInputComponent };
//# sourceMappingURL=parameter-input.component.js.map