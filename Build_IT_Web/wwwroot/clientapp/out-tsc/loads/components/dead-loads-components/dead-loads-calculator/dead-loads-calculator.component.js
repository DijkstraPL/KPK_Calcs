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
import { LoadUnit } from '../../../models/dead-loads/enums/loadUnit';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
var DeadLoadsCalculatorComponent = /** @class */ (function () {
    function DeadLoadsCalculatorComponent(deadLoadsService) {
        this.deadLoadsService = deadLoadsService;
        this.myControl = new FormControl();
        this.selectedMaterials = [];
        this.units = [
            { key: LoadUnit.kilonewton, value: 'kg' },
            { key: LoadUnit.kilonewton_per_meter, value: 'kg/m' },
            { key: LoadUnit.kilonewton_per_square_meter, value: 'kg/m<sup>2</sup>' },
            { key: LoadUnit.kilonewton_per_cubic_meter, value: 'kg/m<sup>3</sup>' },
        ];
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
            _this.subcategories = subcategories.sort(function (subcategory, nextSubcategory) {
                return nextSubcategory.documentName.localeCompare(subcategory.documentName);
            });
            console.log("Subcategories", _this.subcategories);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsCalculatorComponent.prototype.onSubcategoryChange = function () {
        var _this = this;
        this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
            .subscribe(function (materials) {
            _this.materials = materials;
            console.log("Materials", _this.materials);
            alert(materials[0].additions);
        }, function (error) { return console.error(error); });
    };
    DeadLoadsCalculatorComponent.prototype.addMaterial = function (material) {
        var _this = this;
        var categoryName = this.selectedCategory.name + ' ' + this.selectedSubcategory.name;
        this.selectedMaterials.push(new MaterialForCalculations(categoryName, material));
        this.selectedMaterials.forEach(function (m) { return _this.calculate(m); });
    };
    DeadLoadsCalculatorComponent.prototype.removeMaterial = function (index) {
        this.selectedMaterials.splice(index, 1);
    };
    DeadLoadsCalculatorComponent.prototype.calculate = function (materialForCalculation) {
        materialForCalculation.calculate();
        this.setSums();
    };
    DeadLoadsCalculatorComponent.prototype.setSums = function () {
        var _this = this;
        this.sumMinimumDeadLoads = 0;
        this.sumMaximumDeadLoads = 0;
        if (this.selectedMaterials.every(function (m) { return m.unit == _this.selectedMaterials[0].unit; })) {
            this.selectedMaterials.forEach(function (m) { return _this.sumMinimumDeadLoads += m.calculatedMinimumLoad; });
            this.selectedMaterials.forEach(function (m) { return _this.sumMaximumDeadLoads += m.calculatedMaximumLoad; });
        }
        else {
            this.sumMinimumDeadLoads = undefined;
            this.sumMaximumDeadLoads = undefined;
        }
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