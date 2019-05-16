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
import { DeadLoadsService } from '../../../services/dead-loads.service';
var DeadLoadsComponent = /** @class */ (function () {
    //sumMinimumDeadLoads: number;
    //sumMaximumDeadLoads: number;
    //materialsDisplayedColumns: string[] = ['name', 'minDensity', 'maxDensity', 'unit', 'add'];
    //materialsForCalculationsDisplayedColumns: string[]
    //    = ['category', 'name', 'length', 'width', 'thickness', 'minDensity', 'maxDensity', 'unit', 'remove'];
    //selectedMaterialDataSource: MatTableDataSource<MaterialForCalculations>
    //    = new MatTableDataSource(this.selectedMaterials);;
    //@ViewChild(MatTable) selectedMaterialTable: MatTable<any>;
    //units = [
    //    { key: LoadUnit.kilonewton, value: 'kN' },
    //    { key: LoadUnit.kilonewton_per_meter, value: 'kN/m' },
    //    { key: LoadUnit.kilonewton_per_square_meter, value: 'kN/m<sup>2</sup>' },
    //    { key: LoadUnit.kilonewton_per_cubic_meter, value: 'kN/m<sup>3</sup>' },
    //]
    function DeadLoadsComponent(deadLoadsService) {
        this.deadLoadsService = deadLoadsService;
        //myControl = new FormControl();
        //categories: Category[];
        //selectedCategory: Category;
        //subcategories: Subcategory[];
        //selectedSubcategory: Subcategory;
        //materials: Material[];
        this.selectedMaterials = [];
    }
    DeadLoadsComponent.prototype.onMaterialAdded = function (material) {
        this.selectedMaterials.push(material);
    };
    DeadLoadsComponent.prototype.ngOnInit = function () {
        //this.deadLoadsService.getCategories().subscribe(categories => {
        //    this.categories = categories;
        //    console.log("Categories", this.categories);
        //}, error => console.error(error));
    };
    DeadLoadsComponent = __decorate([
        Component({
            selector: 'app-dead-loads',
            templateUrl: './dead-loads.component.html',
            styleUrls: ['./dead-loads.component.less']
        }),
        __metadata("design:paramtypes", [DeadLoadsService])
    ], DeadLoadsComponent);
    return DeadLoadsComponent;
}());
export { DeadLoadsComponent };
//# sourceMappingURL=dead-loads.component.js.map