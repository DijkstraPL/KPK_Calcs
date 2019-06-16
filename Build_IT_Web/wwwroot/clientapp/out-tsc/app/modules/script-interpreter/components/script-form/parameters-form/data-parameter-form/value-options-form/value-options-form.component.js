var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../../common/errors/app-error-state-matcher';
import { ValueOptionSettings } from '../../../../../models/enums/valueOptionSettings';
var ValueOptionsFormComponent = /** @class */ (function () {
    function ValueOptionsFormComponent() {
        this.valueOptionSettings = ValueOptionSettings;
        this.matcher = new AppErrorStateMatcher();
    }
    Object.defineProperty(ValueOptionsFormComponent.prototype, "parameterValueOptionSetting", {
        get: function () {
            return this.parameterForm.get('valueOptionSetting');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ValueOptionsFormComponent.prototype, "parameterValueOptions", {
        get: function () {
            return this.parameterForm.get('valueOptions');
        },
        enumerable: true,
        configurable: true
    });
    ValueOptionsFormComponent.prototype.addValueOption = function () {
        this.parameterValueOptions.push(new FormGroup({
            id: new FormControl(0),
            name: new FormControl(''),
            value: new FormControl(''),
            description: new FormControl('')
        }));
    };
    ValueOptionsFormComponent.prototype.remove = function (valueOption) {
        var index = this.parameterValueOptions.controls.indexOf(valueOption);
        if (index >= 0) {
            this.parameterValueOptions.removeAt(index);
        }
    };
    ValueOptionsFormComponent.prototype.booleanSettingChecked = function (checkbox) {
        if (checkbox.value == this.valueOptionSettings.Boolean)
            while (this.parameterValueOptions.length !== 0) {
                this.parameterValueOptions.removeAt(0);
            }
    };
    __decorate([
        Input('parameterForm'),
        __metadata("design:type", FormGroup)
    ], ValueOptionsFormComponent.prototype, "parameterForm", void 0);
    ValueOptionsFormComponent = __decorate([
        Component({
            selector: 'app-value-options-form',
            templateUrl: './value-options-form.component.html',
            styleUrls: ['./value-options-form.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ValueOptionsFormComponent);
    return ValueOptionsFormComponent;
}());
export { ValueOptionsFormComponent };
//# sourceMappingURL=value-options-form.component.js.map