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
var ParameterSelectComponent = /** @class */ (function () {
    function ParameterSelectComponent() {
        this.parameter = null;
        this.valueChanged = new EventEmitter();
        this.parameterOptions = ParameterOptions;
    }
    ParameterSelectComponent.prototype.ngOnInit = function () {
    };
    ParameterSelectComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    ParameterSelectComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterSelectComponent.prototype, "parameter", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterSelectComponent.prototype, "valueChanged", void 0);
    ParameterSelectComponent = __decorate([
        Component({
            selector: 'parameter-select',
            templateUrl: './parameter-select.component.html',
            styleUrls: ['./parameter-select.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterSelectComponent);
    return ParameterSelectComponent;
}());
export { ParameterSelectComponent };
//# sourceMappingURL=parameter-select.component.js.map