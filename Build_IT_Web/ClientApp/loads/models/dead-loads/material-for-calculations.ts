import { Material } from "./interfaces/material";

export class MaterialForCalculations {
    categoryName: string;
    material: Material;
    calculatedMinimumLoad: number;
    calculatedMaximumLoad: number;
    width: number;
    height: number;
    thickness: number;

    constructor(categoryName: string, material: Material) {
        this.categoryName = categoryName;
        this.material = material;
    }

    calculate() {
        let width = 1;
        let height = 1;
        let thickness = 1;

        if (this.width != undefined)
            width = this.width /100;
        if (this.height != undefined)
            height = this.height / 100;
        if (this.thickness != undefined)
            thickness = this.thickness / 100;

        this.calculatedMinimumLoad = this.material.minimumDensity * width * height *  thickness;
        this.calculatedMaximumLoad = this.material.maximumDensity * width * height *  thickness;
    }
}