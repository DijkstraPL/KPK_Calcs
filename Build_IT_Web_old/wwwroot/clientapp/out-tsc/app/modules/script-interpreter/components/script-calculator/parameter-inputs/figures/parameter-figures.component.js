var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
var ParameterFiguresComponent = /** @class */ (function () {
    function ParameterFiguresComponent(dialogRef, parameter) {
        this.dialogRef = dialogRef;
        this.parameter = parameter;
    }
    ParameterFiguresComponent.prototype.onCloseClick = function () {
        this.dialogRef.close();
    };
    ParameterFiguresComponent = __decorate([
        Component({
            selector: 'parameter-figures',
            templateUrl: './parameter-figures.component.html',
            styleUrls: ['./parameter-figures.component.scss']
        }),
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object])
    ], ParameterFiguresComponent);
    return ParameterFiguresComponent;
}());
export { ParameterFiguresComponent };
//# sourceMappingURL=parameter-figures.component.js.map