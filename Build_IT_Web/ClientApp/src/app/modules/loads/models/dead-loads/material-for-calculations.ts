import { AdditionForCalculations } from "./addition-for-calculations";
import { LoadUnit } from "./enums/loadUnit";
import { Material } from "./interfaces/material";

export class MaterialForCalculations {
    categoryName: string;
    material: Material;
    calculatedMinimumLoad: number;
    calculatedMaximumLoad: number;
    length: number;
    width: number;
    thickness: number;
    unit: LoadUnit;
    additions: AdditionForCalculations[] = [];

    constructor(categoryName: string, material: Material) {
        this.categoryName = categoryName;
        this.material = material;
        this.unit = this.material.unit;
        this.material.additions.forEach(a => this.additions.push(new AdditionForCalculations(a)));
    }

    calculate() {
        let length = 1;
        let width = 1;
        let thickness = 1;

        this.unit = this.material.unit;

        if (this.length != undefined) {
            length = this.length / 100;
            this.unit -= 1;
        }
        if (this.width != undefined) {
            width = this.width / 100;
            this.unit -= 1;
        }
        if (this.thickness != undefined) {
            thickness = this.thickness / 100;
            this.unit -= 1; 
        }

        let addition = 0;
        this.additions.filter(a => a.isChecked)
            .forEach(a => addition += a.origin.value);

        this.calculatedMinimumLoad =
            (this.material.minimumDensity + addition)
            * length * width * thickness;
        this.calculatedMaximumLoad =
            (this.material.maximumDensity + addition)
            * length * width * thickness;
    }
}