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
import { ValueOptionSettings } from '../../../../models/enums/valueOptionSettings';
var ParameterFormComponent = /** @class */ (function () {
    function ParameterFormComponent() {
        this.valueOptionSetting = ValueOptionSettings;
        this.parameter = null;
        this.valueChanged = new EventEmitter();
    }
    ParameterFormComponent.prototype.ngOnInit = function () {
    };
    ParameterFormComponent.prototype.onValueChanged = function (parameter) {
        this.valueChanged.emit(parameter);
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterFormComponent.prototype, "parameter", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterFormComponent.prototype, "valueChanged", void 0);
    ParameterFormComponent = __decorate([
        Component({
            selector: 'parameter-form',
            templateUrl: './parameter-form.component.html',
            styleUrls: ['./parameter-form.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterFormComponent);
    return ParameterFormComponent;
}());
export { ParameterFormComponent };
//# sourceMappingURL=parameter-form.component.js.map