import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Material } from '../../../models/dead-loads/interfaces/material';
import { DeadLoadsService } from '../../../services/dead-loads.service';
import { Category } from '../../../models/dead-loads/interfaces/category';
import { Subcategory } from '../../../models/dead-loads/interfaces/subcategory';
import { LoadUnit } from '../../../models/dead-loads/enums/loadUnit';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';

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

    units = [
        { key: LoadUnit.kilonewton, value: 'kg' },
        { key: LoadUnit.kilonewton_per_meter, value: 'kg/m' },
        { key: LoadUnit.kilonewton_per_square_meter, value: 'kg/m<sup>2</sup>' },
        { key: LoadUnit.kilonewton_per_cubic_meter, value: 'kg/m<sup>3</sup>' },
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
                console.log("Subcategories", this.subcategories);
            }, error => console.error(error));
    }

    onSubcategoryChange(): void {
        this.deadLoadsService.getMaterials(this.selectedSubcategory.id)
            .subscribe(materials => {
                this.materials = materials;
                console.log("Materials", this.materials);
            }, error => console.error(error));
    }

    addMaterial(material: Material): void {
        let categoryName = this.selectedCategory.name + ' ' + this.selectedSubcategory.name;
        this.selectedMaterials.push(new MaterialForCalculations(categoryName, material));
    }

    removeMaterial(index: number): void {
        this.selectedMaterials.splice(index, 1);
    }

    calculate(materialForCalculation: MaterialForCalculations): void {
        materialForCalculation.calculate();
        this.setSums();
    }

    setSums(): void {
        this.sumMinimumDeadLoads = 0;
        this.sumMaximumDeadLoads = 0;
        this.selectedMaterials.forEach(m => this.sumMinimumDeadLoads += m.calculatedMinimumLoad);
        this.selectedMaterials.forEach(m => this.sumMaximumDeadLoads += m.calculatedMaximumLoad);
    }
}