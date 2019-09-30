var ParametersGroup = /** @class */ (function () {
    function ParametersGroup(name) {
        this.parameters = [];
        this.name = name;
    }
    ParametersGroup.prototype.addParameter = function (parameter) {
        this.parameters.push(parameter);
    };
    ParametersGroup.prototype.clear = function () {
        this.parameters = [];
    };
    return ParametersGroup;
}());
export { ParametersGroup };
//# sourceMappingURL=parametersGroup.js.map