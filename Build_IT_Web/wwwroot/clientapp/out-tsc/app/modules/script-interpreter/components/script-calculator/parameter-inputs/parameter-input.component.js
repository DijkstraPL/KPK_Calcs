var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, EventEmitter, Output } from '@angular/core';
var ParameterInputComponent = /** @class */ (function () {
    function ParameterInputComponent(parameter) {
        this.valueChanged = new EventEmitter();
        this.parameter = parameter;
    }
    ParameterInputComponent.prototype.ngOnInit = function () {
    };
    ParameterInputComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterInputComponent.prototype, "valueChanged", void 0);
    ParameterInputComponent = __decorate([
        Component({
            selector: 'bit-parameter-input',
            templateUrl: './parameter-input.component.html',
            styleUrls: ['./parameter-input.component.less']
        }),
        __metadata("design:paramtypes", [Object])
    ], ParameterInputComponent);
    return ParameterInputComponent;
}());
export { ParameterInputComponent };
//# sourceMappingURL=parameter-input.component.js.map