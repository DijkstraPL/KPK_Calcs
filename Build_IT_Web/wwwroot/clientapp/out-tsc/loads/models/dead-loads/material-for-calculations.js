var MaterialForCalculations = /** @class */ (function () {
    function MaterialForCalculations(categoryName, material) {
        this.categoryName = categoryName;
        this.material = material;
        this.unit = this.material.unit;
    }
    MaterialForCalculations.prototype.calculate = function () {
        var length = 1;
        var width = 1;
        var thickness = 1;
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
        this.calculatedMinimumLoad = this.material.minimumDensity * length * width * thickness;
        this.calculatedMaximumLoad = this.material.maximumDensity * length * width * thickness;
    };
    return MaterialForCalculations;
}());
export { MaterialForCalculations };
//# sourceMappingURL=material-for-calculations.js.map