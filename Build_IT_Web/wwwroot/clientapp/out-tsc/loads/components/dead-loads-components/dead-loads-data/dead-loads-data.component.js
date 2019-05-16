var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Output, EventEmitter } from '@angular/core';
import { DeadLoadsService } from '../../../services/dead-loads.service';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { Units } from '../../../models/dead-loads/units';
var DeadLoadsDataComponent = /** @class */ (function () {
    // Constructor
    function DeadLoadsDataComponent(deadLoadsService) {
        this.deadLoadsService = deadLoadsService;
        this.materialsDisplayedColumns = ['name', 'minDensity', 'maxDensity', 'unit', 'add'];
        this.materialAdded = new EventEmitter();
    }
    Object.defineProperty(DeadLoadsDataComponent.prototype, "units", {
        get: function () {
            return Units.loadUnit;
        },
        enumerable: true,
        configurable: true
    });
    DeadLoadsDataComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.deadLoadsService.getCategories().subscribe(function (categories) {
            _this.categories = categories;
            console.log("Categories", _this.categories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsDataComponent.prototype.onCategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getSubcategories(this.selectedCategory.id)
            .subscribe(function (subcategories) {
            _this.subcategories = subcategories.sort(function (subcategory, nextSubcategory) {
                return nextSubcategory.documentName.localeCompare(subcategory.documentName);
            });
            _this.materials = null;
            console.log("Subcategories", _this.subcategories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsDataComponent.prototype.onSubcategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
            .subscribe(function (materials) {
            _this.materials = materials;
            console.log("Materials", _this.materials);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsDataComponent.prototype.addMaterial = function (material) {
        var categoryName = this.selectedCategory.name + ' ' + this.selectedSubcategory.name;
        this.materialAdded.emit(new MaterialForCalculations(categoryName, material));
    };
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], DeadLoadsDataComponent.prototype, "materialAdded", void 0);
    DeadLoadsDataComponent = __decorate([
        Component({
            selector: 'app-dead-loads-data',
            templateUrl: './dead-loads-data.component.html',
            styleUrls: ['./dead-loads-data.component.less']
        }),
        __metadata("design:paramtypes", [DeadLoadsService])
    ], DeadLoadsDataComponent);
    return DeadLoadsDataComponent;
}());
export { DeadLoadsDataComponent };
//# sourceMappingURL=dead-loads-data.component.js.map