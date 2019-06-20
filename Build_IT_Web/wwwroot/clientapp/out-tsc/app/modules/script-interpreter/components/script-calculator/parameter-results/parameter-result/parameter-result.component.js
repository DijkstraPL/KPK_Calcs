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
import { ValueType } from '../../../../models/enums/valueType';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';
var ParameterResultComponent = /** @class */ (function () {
    function ParameterResultComponent() {
        this.parameter = null;
        //valueClass: string;
        //forbiddenSigns = ['(', ')', ',', '.', '^'];
        this.valueTypes = ValueType;
        this.valueTypesMapping = { 'number': 0, 'text': 1 };
    }
    ParameterResultComponent.prototype.ngOnInit = function () {
        // this.forbiddenSigns.forEach(fs => this.valueClass = this.parameter.name.replace(fs, ''));
    };
    ParameterResultComponent.prototype.isImportant = function () {
        return (this.parameter.context & ParameterOptions.important) != 0;
    };
    __decorate([
        Input('parameter'),
        __metadata("design:type", Object)
    ], ParameterResultComponent.prototype, "parameter", void 0);
    ParameterResultComponent = __decorate([
        Component({
            selector: 'parameter-result',
            templateUrl: './parameter-result.component.html',
            styleUrls: ['./parameter-result.component.scss']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterResultComponent);
    return ParameterResultComponent;
}());
export { ParameterResultComponent };
//# sourceMappingURL=parameter-result.component.js.map