import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../../../models/dead-loads/interfaces/category';
import { Material } from '../../../models/dead-loads/interfaces/material';
import { Subcategory } from '../../../models/dead-loads/interfaces/subcategory';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { Units } from '../../../models/dead-loads/units';
import { DeadLoadsService } from '../../../services/dead-loads.service';

@Component({
    selector: 'app-dead-loads-data',
    templateUrl: './dead-loads-data.component.html',
    styleUrls: ['./dead-loads-data.component.scss']
})

export class DeadLoadsDataComponent implements OnInit {

    // Fields
    categories: Category[];
    selectedCategory: Category;
    subcategories: Subcategory[];
    selectedSubcategory: Subcategory;
    materials: Material[];
   
    materialsDisplayedColumns: string[] = ['name', 'minDensity', 'maxDensity', 'unit', 'add'];

    @Output() materialAdded = new EventEmitter<MaterialForCalculations>();

    get units() {
        return Units.loadUnit;
    }

    // Constructor
    constructor(private deadLoadsService: DeadLoadsService) {
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
        this.materialAdded.emit(new MaterialForCalculations(categoryName, material));
    }
}