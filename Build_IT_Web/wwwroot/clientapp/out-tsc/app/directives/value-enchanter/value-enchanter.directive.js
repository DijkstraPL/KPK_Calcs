var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Directive, HostListener, ElementRef } from '@angular/core';
var ValueEnchanterDirective = /** @class */ (function () {
    function ValueEnchanterDirective(el) {
        this.el = el;
    }
    ValueEnchanterDirective.prototype.onChange = function () {
        var value = this.el.nativeElement.value;
        this.el.nativeElement.value = value + 2;
    };
    __decorate([
        HostListener('changed'),
        __metadata("design:type", Function),
        __metadata("design:paramtypes", []),
        __metadata("design:returntype", void 0)
    ], ValueEnchanterDirective.prototype, "onChange", null);
    ValueEnchanterDirective = __decorate([
        Directive({
            selector: '[app-value-enchanter]'
        }),
        __metadata("design:paramtypes", [ElementRef])
    ], ValueEnchanterDirective);
    return ValueEnchanterDirective;
}());
export { ValueEnchanterDirective };
//# sourceMappingURL=value-enchanter.directive.js.map