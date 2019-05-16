var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, Input, ViewChild } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { Units } from '../../../models/dead-loads/units';
var DeadLoadsCalculatorComponent = /** @class */ (function () {
    function DeadLoadsCalculatorComponent() {
        this.selectedMaterials = [];
        this.materialsForCalculationsDisplayedColumns = ['position', 'category', 'name', 'length', 'width', 'thickness', 'minDensity', 'maxDensity', 'unit', 'remove'];
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
    DeadLoadsCalculatorComponent.prototype.ngOnInit = function () {
    };
    Object.defineProperty(DeadLoadsCalculatorComponent.prototype, "newMaterial", {
        set: function (material) {
            var _this = this;
            if (material != null)
                this.selectedMaterials.push(material);
            if (this.selectedMaterialTable)
                this.selectedMaterialTable.renderRows();
            this.selectedMaterials.forEach(function (m) { return _this.calculate(m); });
        },
        enumerable: true,
        configurable: true
    });
    DeadLoadsCalculatorComponent.prototype.dropTable = function (event) {
        var prevIndex = this.selectedMaterials.findIndex(function (d) { return d === event.item.data; });
        moveItemInArray(this.selectedMaterials, prevIndex, event.currentIndex);
        this.selectedMaterialTable.renderRows();
    };
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
        __metadata("design:type", MaterialForCalculations),
        __metadata("design:paramtypes", [MaterialForCalculations])
    ], DeadLoadsCalculatorComponent.prototype, "newMaterial", null);
    DeadLoadsCalculatorComponent = __decorate([
        Component({
            selector: 'app-dead-loads-calculator',
            templateUrl: './dead-loads-calculator.component.html',
            styleUrls: ['./dead-loads-calculator.component.less']
        }),
        __metadata("design:paramtypes", [])
    ], DeadLoadsCalculatorComponent);
    return DeadLoadsCalculatorComponent;
}());
export { DeadLoadsCalculatorComponent };
//# sourceMappingURL=dead-loads-calculator.component.js.map