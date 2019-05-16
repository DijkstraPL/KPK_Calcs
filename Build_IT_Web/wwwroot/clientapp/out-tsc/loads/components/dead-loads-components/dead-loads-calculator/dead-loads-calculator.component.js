var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild, Input } from '@angular/core';
import { DeadLoadsService } from '../../../services/dead-loads.service';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { Units } from '../../../models/dead-loads/units';
var DeadLoadsCalculatorComponent = /** @class */ (function () {
    //units = [
    //    { key: LoadUnit.kilonewton, value: 'kN' },
    //    { key: LoadUnit.kilonewton_per_meter, value: 'kN/m' },
    //    { key: LoadUnit.kilonewton_per_square_meter, value: 'kN/m<sup>2</sup>' },
    //    { key: LoadUnit.kilonewton_per_cubic_meter, value: 'kN/m<sup>3</sup>' },
    //]
    function DeadLoadsCalculatorComponent(deadLoadsService) {
        this.deadLoadsService = deadLoadsService;
        //myControl = new FormControl();
        //categories: Category[];
        //selectedCategory: Category;
        //subcategories: Subcategory[];
        //selectedSubcategory: Subcategory;
        //materials: Material[];
        this._selectedMaterials = [];
        //materialsDisplayedColumns: string[] = ['name', 'minDensity', 'maxDensity', 'unit', 'add'];
        this.materialsForCalculationsDisplayedColumns = ['category', 'name', 'length', 'width', 'thickness', 'minDensity', 'maxDensity', 'unit', 'remove'];
        this.selectedMaterialDataSource = new MatTableDataSource(this.selectedMaterials);
    }
    ;
    Object.defineProperty(DeadLoadsCalculatorComponent.prototype, "units", {
        get: function () {
            return Units.loadUnit;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DeadLoadsCalculatorComponent.prototype, "selectedMaterials", {
        get: function () {
            return this._selectedMaterials;
        },
        set: function (materials) {
            var _this = this;
            this._selectedMaterials = materials;
            this.selectedMaterialTable.renderRows();
            this.selectedMaterials.forEach(function (m) { return _this.calculate(m); });
        },
        enumerable: true,
        configurable: true
    });
    DeadLoadsCalculatorComponent.prototype.ngOnInit = function () {
        //this.deadLoadsService.getCategories().subscribe(categories => {
        //    this.categories = categories;
        //    console.log("Categories", this.categories);
        //}, error => console.error(error));
    };
    //onCategoryChange(): void {
    //    this.deadLoadsService.getSubcategories(this.selectedCategory.id)
    //        .subscribe(subcategories => {
    //            this.subcategories = subcategories.sort(
    //                (subcategory, nextSubcategory) => {
    //                    return nextSubcategory.documentName.localeCompare(subcategory.documentName);
    //                });
    //            this.materials = null;
    //            console.log("Subcategories", this.subcategories);
    //        }, error => console.error(error));
    //}
    //onSubcategoryChange(): void {
    //    this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
    //        .subscribe((materials: Material[]) => {
    //            this.materials = materials;
    //            console.log("Materials", this.materials);
    //        }, error => console.error(error));
    //}
    //addMaterial(material: Material): void {
    //    let categoryName = this.selectedCategory.name + ' ' + this.selectedSubcategory.name;
    //    this.selectedMaterials.push(new MaterialForCalculations(categoryName, material));
    //    this.selectedMaterialTable.renderRows();
    //    this.selectedMaterials.forEach(m => this.calculate(m));
    //}
    DeadLoadsCalculatorComponent.prototype.removeMaterial = function (material) {
        var _this = this;
        var index = this.selectedMaterials.indexOf(material, 0);
        if (index > -1)
            this.selectedMaterials.splice(index, 1);
        this.selectedMaterialTable.renderRows();
        this.selectedMaterials.forEach(function (m) { return _this.calculate(m); });
    };
    DeadLoadsCalculatorComponent.prototype.calculate = function (materialForCalculation) {
        materialForCalculation.calculate();
        this.setSums();
    };
    DeadLoadsCalculatorComponent.prototype.setSums = function () {
        var _this = this;
        this.sumMinimumDeadLoads = 0;
        this.sumMaximumDeadLoads = 0;
        if (this.isUnitsProper()) {
            this.selectedMaterials.forEach(function (m) { return _this.sumMinimumDeadLoads += m.calculatedMinimumLoad; });
            this.selectedMaterials.forEach(function (m) { return _this.sumMaximumDeadLoads += m.calculatedMaximumLoad; });
        }
        else {
            this.sumMinimumDeadLoads = undefined;
            this.sumMaximumDeadLoads = undefined;
        }
    };
    DeadLoadsCalculatorComponent.prototype.isUnitsProper = function () {
        var _this = this;
        return this.selectedMaterials.every(function (m) { return m.unit == _this.selectedMaterials[0].unit; });
    };
    DeadLoadsCalculatorComponent.prototype.additionChecked = function (materialForCalculation, addition) {
        addition.isChecked = !addition.isChecked;
        this.calculate(materialForCalculation);
    };
    __decorate([
        ViewChild(MatTable),
        __metadata("design:type", MatTable)
    ], DeadLoadsCalculatorComponent.prototype, "selectedMaterialTable", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Array),
        __metadata("design:paramtypes", [Array])
    ], DeadLoadsCalculatorComponent.prototype, "selectedMaterials", null);
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