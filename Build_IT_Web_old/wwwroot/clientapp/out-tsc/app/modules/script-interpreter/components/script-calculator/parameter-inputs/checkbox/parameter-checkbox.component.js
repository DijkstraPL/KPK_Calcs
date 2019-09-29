var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, EventEmitter, Output, Input, ViewChild } from '@angular/core';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
import { MatCheckbox } from '@angular/material/checkbox';
var ParameterCheckboxComponent = /** @class */ (function () {
    function ParameterCheckboxComponent() {
        this.parameter = null;
        this.valueChanged = new EventEmitter();
        this.parameterOptions = ParameterOptions;
    }
    ParameterCheckboxComponent.prototype.ngOnInit = function () {
        if (this.isRequired() && this.parameter.value != 'true')
            this.parameter.value = 'false';
    };
    ParameterCheckboxComponent.prototype.ngAfterViewInit = function () {
        if (!this.isRequired())
            this.defaultField.checked = this.parameter.value == '';
        else
            this.checkboxField.checked = this.parameter.value == 'true';
        if (this.defaultField)
            this.isDefault = this.defaultField.checked;
    };
    ParameterCheckboxComponent.prototype.changeValue = function (event) {
        this.parameter.value = event.checked ? 'true' : 'false';
        this.valueChanged.emit(this.parameter);
    };
    ParameterCheckboxComponent.prototype.isRequired = function () {
        return (this.parameter.context & this.parameterOptions.optional) == 0;
    };
    ParameterCheckboxComponent.prototype.defaultChecked = function (event) {
        if (event.checked) {
            this.parameter.value = null;
            this.isDefault = true;
        }
        else
            this.isDefault = false;
        this.valueChanged.emit(this.parameter);
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterCheckboxComponent.prototype, "parameter", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterCheckboxComponent.prototype, "valueChanged", void 0);
    __decorate([
        ViewChild('defaultField', { static: false }),
        __metadata("design:type", MatCheckbox)
    ], ParameterCheckboxComponent.prototype, "defaultField", void 0);
    __decorate([
        ViewChild('checkboxField', { static: false }),
        __metadata("design:type", MatCheckbox)
    ], ParameterCheckboxComponent.prototype, "checkboxField", void 0);
    ParameterCheckboxComponent = __decorate([
        Component({
            selector: 'parameter-checkbox',
            templateUrl: './parameter-checkbox.component.html',
            styleUrls: ['./parameter-checkbox.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterCheckboxComponent);
    return ParameterCheckboxComponent;
}());
export { ParameterCheckboxComponent };
//# sourceMappingURL=parameter-checkbox.component.js.map