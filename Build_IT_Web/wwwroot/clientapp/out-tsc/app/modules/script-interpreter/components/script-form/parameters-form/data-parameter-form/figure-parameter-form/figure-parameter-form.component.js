var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild, ElementRef, Input } from '@angular/core';
import { FigureService } from '../../../../../services/figure.service';
import { FormGroup } from '@angular/forms';
var FigureParameterFormComponent = /** @class */ (function () {
    function FigureParameterFormComponent(figureService) {
        this.figureService = figureService;
    }
    Object.defineProperty(FigureParameterFormComponent.prototype, "parameterId", {
        get: function () {
            return this.parameterForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(FigureParameterFormComponent.prototype, "parameterFigures", {
        get: function () {
            return this.parameterForm.get('figures');
        },
        enumerable: true,
        configurable: true
    });
    FigureParameterFormComponent.prototype.ngOnInit = function () {
        this.figures = this.parameterFigures.value;
    };
    FigureParameterFormComponent.prototype.uploadFigure = function () {
        var _this = this;
        var nativeELement = this.fileInput.nativeElement;
        this.figureService.upload(this.parameterId.value, nativeELement.files[0])
            .subscribe(function (figure) {
            _this.figures.push(figure);
        });
    };
    __decorate([
        Input('parameterForm'),
        __metadata("design:type", FormGroup)
    ], FigureParameterFormComponent.prototype, "parameterForm", void 0);
    __decorate([
        ViewChild('fileInput', { static: false }),
        __metadata("design:type", ElementRef)
    ], FigureParameterFormComponent.prototype, "fileInput", void 0);
    FigureParameterFormComponent = __decorate([
        Component({
            selector: 'app-figure-parameter-form',
            templateUrl: './figure-parameter-form.component.html',
            styleUrls: ['./figure-parameter-form.component.scss']
        }),
        __metadata("design:paramtypes", [FigureService])
    ], FigureParameterFormComponent);
    return FigureParameterFormComponent;
}());
export { FigureParameterFormComponent };
//# sourceMappingURL=figure-parameter-form.component.js.map