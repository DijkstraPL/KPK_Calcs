import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Material } from '../../../models/dead-loads/interfaces/material';
import { DeadLoadsService } from '../../../services/dead-loads.service';
import { Category } from '../../../models/dead-loads/interfaces/category';
import { Subcategory } from '../../../models/dead-loads/interfaces/subcategory';
import { LoadUnit } from '../../../models/dead-loads/enums/loadUnit';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { Addition } from '../../../models/dead-loads/interfaces/addition';
import { AdditionForCalculations } from '../../../models/dead-loads/addition-for-calculations';
import { MatTableDataSource, MatTable } from '@angular/material/table';

@Component({
    selector: 'app-dead-loads-calculator',
    templateUrl: './dead-loads-calculator.component.html',
    styleUrls: ['./dead-loads-calculator.component.less']
})

export class DeadLoadsCalculatorComponent implements OnInit {
    myControl = new FormControl();

    categories: Category[];
    selectedCategory: Category;
    subcategories: Subcategory[];
    selectedSubcategory: Subcategory;
    materials: Material[];
    selectedMaterials: MaterialForCalculations[] = [];
    sumMinimumDeadLoads: number;
    sumMaximumDeadLoads: number;

    materialsDisplayedColumns: string[] = ['name', 'minDensity', 'maxDensity', 'unit', 'add'];
    materialsForCalculationsDisplayedColumns: string[]
        = ['category', 'name', 'length', 'width', 'thickness', 'minDensity', 'maxDensity', 'unit', 'remove'];
    selectedMaterialDataSource: MatTableDataSource<MaterialForCalculations>
        = new MatTableDataSource(this.selectedMaterials);;
    @ViewChild(MatTable) selectedMaterialTable: MatTable<any>;

    units = [
        { key: LoadUnit.kilonewton, value: 'kN' },
        { key: LoadUnit.kilonewton_per_meter, value: 'kN/m' },
        { key: LoadUnit.kilonewton_per_square_meter, value: 'kN/m<sup>2</sup>' },
        { key: LoadUnit.kilonewton_per_cubic_meter, value: 'kN/m<sup>3</sup>' },
    ]

    constructor(
        private deadLoadsService: DeadLoadsService) {
    }

    ngOnInit(): void {
        this.deadLoadsService.getCategories().subscribe(categories => {
            this.categories = categories;
            console.log("Categories", this.categories);
        }, error => console.error(error));

    }

    onCategoryChange(): void {
        this.deadLoadsService.getSubcategories(this.selectedCategory.id)
            .subscribe(subcategories => {
                this.subcategories = subcategories.sort(
                    (subcategory, nextSubcategory) => {
                        return nextSubcategory.documentName.localeCompare(subcategory.documentName);
                    });
                this.materials = null;
                console.log("Subcategories", this.subcategories);
            }, error => console.error(error));
    }

    onSubcategoryChange(): void {
        this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
            .subscribe((materials: Material[]) => {
                this.materials = materials;
                console.log("Materials", this.materials);
            }, error => console.error(error));
    }

    addMaterial(material: Material): void {
        let categoryName = this.selectedCategory.name + ' ' + this.selectedSubcategory.name;
        this.selectedMaterials.push(new MaterialForCalculations(categoryName, material));
        this.selectedMaterialTable.renderRows();
        this.selectedMaterials.forEach(m => this.calculate(m));
    }

    removeMaterial(material: MaterialForCalculations): void {
        const index = this.selectedMaterials.indexOf(material, 0);
        if (index > -1)
            this.selectedMaterials.splice(index, 1);
        this.selectedMaterialTable.renderRows();
        this.selectedMaterials.forEach(m => this.calculate(m));
    }

    calculate(materialForCalculation: MaterialForCalculations): void {
        materialForCalculation.calculate();
        this.setSums();
    }

    setSums(): void {
        this.sumMinimumDeadLoads = 0;
        this.sumMaximumDeadLoads = 0;

        if (this.isUnitsProper()) {
            this.selectedMaterials.forEach(m => this.sumMinimumDeadLoads += m.calculatedMinimumLoad);
            this.selectedMaterials.forEach(m => this.sumMaximumDeadLoads += m.calculatedMaximumLoad);
        }
        else {
            this.sumMinimumDeadLoads = undefined;
            this.sumMaximumDeadLoads = undefined;
        }
    }

    isUnitsProper() : boolean {
        return this.selectedMaterials.every(m => m.unit == this.selectedMaterials[0].unit);
    }

    additionChecked(materialForCalculation: MaterialForCalculations,
        addition: AdditionForCalculations): void {
        addition.isChecked = !addition.isChecked;
        this.calculate(materialForCalculation);
    }
}