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
import { FigureService } from '../../../../services/figure.service';
var ParameterFiguresComponent = /** @class */ (function () {
    function ParameterFiguresComponent(figureService) {
        this.figureService = figureService;
    }
    ParameterFiguresComponent.prototype.ngOnInit = function () {
        this.figures = this.parameter.figures;
    };
    ParameterFiguresComponent.prototype.expanded = function () {
        this.isExpanded = true;
    };
    ParameterFiguresComponent.prototype.collapsed = function () {
        this.isExpanded = false;
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterFiguresComponent.prototype, "parameter", void 0);
    ParameterFiguresComponent = __decorate([
        Component({
            selector: 'parameter-figures',
            templateUrl: './parameter-figures.component.html',
            styleUrls: ['./parameter-figures.component.scss']
        }),
        __metadata("design:paramtypes", [FigureService])
    ], ParameterFiguresComponent);
    return ParameterFiguresComponent;
}());
export { ParameterFiguresComponent };
//# sourceMappingURL=parameter-figures.component.js.map