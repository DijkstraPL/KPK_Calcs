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
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ParameterFiguresComponent } from '../figures/parameter-figures.component';
var FiguresButtonComponent = /** @class */ (function () {
    function FiguresButtonComponent(dialog) {
        this.dialog = dialog;
    }
    FiguresButtonComponent.prototype.openFigures = function () {
        var dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = false;
        dialogConfig.autoFocus = true;
        dialogConfig.width = 'auto';
        dialogConfig.data = this.parameter;
        var dialogRef = this.dialog.open(ParameterFiguresComponent, dialogConfig);
        dialogRef.afterClosed().subscribe(function (result) {
        });
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], FiguresButtonComponent.prototype, "parameter", void 0);
    FiguresButtonComponent = __decorate([
        Component({
            selector: 'figures-button',
            templateUrl: './figures-button.component.html',
            styleUrls: ['./figures-button.component.scss']
        }),
        __metadata("design:paramtypes", [MatDialog])
    ], FiguresButtonComponent);
    return FiguresButtonComponent;
}());
export { FiguresButtonComponent };
//# sourceMappingURL=figures-button.component.js.map