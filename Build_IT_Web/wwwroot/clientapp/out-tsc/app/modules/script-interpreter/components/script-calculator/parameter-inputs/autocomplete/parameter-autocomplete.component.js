var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, EventEmitter, Output, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
var ParameterAutocompleteComponent = /** @class */ (function () {
    function ParameterAutocompleteComponent() {
        this.valueOptionsForm = new FormControl();
        this.parameter = null;
        this.valueChanged = new EventEmitter();
    }
    ParameterAutocompleteComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.filteredValueOptions = this.valueOptionsForm.valueChanges.pipe(startWith(''), map(function (value) { return _this._filter(value); }));
    };
    ParameterAutocompleteComponent.prototype._filter = function (value) {
        var filterValue = value.toLowerCase();
        return this.parameter.valueOptions.filter(function (option) {
            return option.value.toLowerCase().indexOf(filterValue) === 0;
        });
    };
    ParameterAutocompleteComponent.prototype.changeValue = function () {
        this.valueChanged.emit(this.parameter);
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], ParameterAutocompleteComponent.prototype, "parameter", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], ParameterAutocompleteComponent.prototype, "valueChanged", void 0);
    ParameterAutocompleteComponent = __decorate([
        Component({
            selector: 'parameter-autocomplete',
            templateUrl: './parameter-autocomplete.component.html',
            styleUrls: ['./parameter-autocomplete.component.less']
        }),
        __metadata("design:paramtypes", [])
    ], ParameterAutocompleteComponent);
    return ParameterAutocompleteComponent;
}());
export { ParameterAutocompleteComponent };
//# sourceMappingURL=parameter-autocomplete.component.js.map