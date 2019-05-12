var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DeadLoadsService } from '../../../services/dead-loads.service';
var DeadLoadsCalculatorComponent = /** @class */ (function () {
    function DeadLoadsCalculatorComponent(deadLoadsService) {
        this.deadLoadsService = deadLoadsService;
        this.myControl = new FormControl();
    }
    DeadLoadsCalculatorComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.deadLoadsService.getCategories().subscribe(function (categories) {
            _this.categories = categories;
            console.log("Categories", _this.categories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsCalculatorComponent.prototype.onCategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getSubcategories(this.selectedCategory.id)
            .subscribe(function (subcategories) {
            _this.subcategories = subcategories;
            console.log("Subcategories", _this.subcategories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsCalculatorComponent.prototype.onSubcategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
            .subscribe(function (materials) {
            _this.materials = materials;
            console.log("Materials", _this.materials);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsCalculatorComponent = __decorate([
        Component({
            selector: 'app-dead-loads-calculator',
            templateUrl: './dead-loads-calculator.component.html',
            styleUrls: ['./dead-loads-calculator.component.less']
        }),
        __metadata("design:paramtypes", [DeadLoadsService])
    ], DeadLoadsCalculatorComponent);
    return DeadLoadsCalculatorComponent;
}());
export { DeadLoadsCalculatorComponent };
//# sourceMappingURL=dead-loads-calculator.component.js.map