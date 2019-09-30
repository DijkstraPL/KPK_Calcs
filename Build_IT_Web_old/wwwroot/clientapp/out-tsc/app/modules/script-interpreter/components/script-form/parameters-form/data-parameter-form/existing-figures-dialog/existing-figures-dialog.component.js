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
import { FigureService } from '../../../../../services/figure.service';
var ExistingFiguresDialogComponent = /** @class */ (function () {
    function ExistingFiguresDialogComponent(dialogRef, figure, figureService) {
        this.dialogRef = dialogRef;
        this.figure = figure;
        this.figureService = figureService;
    }
    ExistingFiguresDialogComponent.prototype.ngOnInit = function () {
        //this.figureService.getAllFigures()
        //    .subscribe(f => this.figures = f);
    };
    ExistingFiguresDialogComponent.prototype.onNoClick = function () {
        this.dialogRef.close();
    };
    ExistingFiguresDialogComponent = __decorate([
        Component({
            selector: 'app-existing-figures-dialog',
            templateUrl: './existing-figures-dialog.component.html',
            styleUrls: ['./existing-figures-dialog.component.scss']
        }),
        __param(1, Inject(MAT_DIALOG_DATA)),
        __metadata("design:paramtypes", [MatDialogRef, Object, FigureService])
    ], ExistingFiguresDialogComponent);
    return ExistingFiguresDialogComponent;
}());
export { ExistingFiguresDialogComponent };
//# sourceMappingURL=existing-figures-dialog.component.js.map