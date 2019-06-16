import { AdditionForCalculations } from "./addition-for-calculations";
var MaterialForCalculations = /** @class */ (function () {
    function MaterialForCalculations(categoryName, material) {
        var _this = this;
        this.additions = [];
        this.categoryName = categoryName;
        this.material = material;
        this.unit = this.material.unit;
        this.material.additions.forEach(function (a) { return _this.additions.push(new AdditionForCalculations(a)); });
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
        var addition = 0;
        this.additions.filter(function (a) { return a.isChecked; })
            .forEach(function (a) { return addition += a.origin.value; });
        this.calculatedMinimumLoad =
            (this.material.minimumDensity + addition)
                * length * width * thickness;
        this.calculatedMaximumLoad =
            (this.material.maximumDensity + addition)
                * length * width * thickness;
    };
    return MaterialForCalculations;
}());
export { MaterialForCalculations };
//# sourceMappingURL=material-for-calculations.js.map