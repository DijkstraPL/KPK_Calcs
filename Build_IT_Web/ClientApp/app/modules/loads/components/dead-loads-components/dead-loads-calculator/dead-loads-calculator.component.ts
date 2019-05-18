import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { AdditionForCalculations } from '../../../models/dead-loads/addition-for-calculations';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { Units } from '../../../models/dead-loads/units';

@Component({
    selector: 'app-dead-loads-calculator',
    templateUrl: './dead-loads-calculator.component.html',
    styleUrls: ['./dead-loads-calculator.component.less']
})

export class DeadLoadsCalculatorComponent implements OnInit {

    selectedMaterials: MaterialForCalculations[] = [];
    sumMinimumDeadLoads: number;
    sumMaximumDeadLoads: number;

    materialsForCalculationsDisplayedColumns: string[]
        = ['position', 'category', 'name', 'length', 'width', 'thickness', 'minDensity', 'maxDensity', 'unit', 'remove'];
    selectedMaterialDataSource: MatTableDataSource<MaterialForCalculations>
        = new MatTableDataSource(this.selectedMaterials);;
    @ViewChild(MatTable) selectedMaterialTable: MatTable<any>;

    get units() {
        return Units.loadUnit;
    }

    constructor() {
    }

    ngOnInit(): void {
    }

    @Input() set newMaterial(material: MaterialForCalculations) {
        if (material != null)
            this.selectedMaterials.push(material);
        if (this.selectedMaterialTable)
            this.selectedMaterialTable.renderRows();
        this.selectedMaterials.forEach(m => this.calculate(m));
    }

    dropTable(event: CdkDragDrop<MaterialForCalculations[]>) {
        const prevIndex = this.selectedMaterials.findIndex((d) => d === event.item.data);
        moveItemInArray(this.selectedMaterials, prevIndex, event.currentIndex);
        this.selectedMaterialTable.renderRows();
    }

    ondrag() {
        console.log("4");
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

    isUnitsProper(): boolean {
        return this.selectedMaterials.every(m => m.unit == this.selectedMaterials[0].unit);
    }

    additionChecked(materialForCalculation: MaterialForCalculations,
        addition: AdditionForCalculations): void {
        addition.isChecked = !addition.isChecked;
        this.calculate(materialForCalculation);
    }
}