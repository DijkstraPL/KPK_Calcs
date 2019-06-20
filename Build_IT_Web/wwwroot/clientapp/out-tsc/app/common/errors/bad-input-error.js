var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import { AppError } from "./app-error";
var BadInputError = /** @class */ (function (_super) {
    __extends(BadInputError, _super);
    function BadInputError(originalError) {
        var _this = _super.call(this, originalError) || this;
        _this.originalError = originalError;
        return _this;
    }
    return BadInputError;
}(AppError));
export { BadInputError };
//# sourceMappingURL=bad-input-error.js.map