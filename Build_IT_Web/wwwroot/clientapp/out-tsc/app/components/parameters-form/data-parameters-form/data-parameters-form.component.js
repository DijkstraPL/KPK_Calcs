var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { ValueOptionImpl } from '../../../models/valueOptionImpl';
var DataParametersFormComponent = /** @class */ (function () {
    function DataParametersFormComponent(parameterService) {
        this.parameterService = parameterService;
        this.newParameter = new ParameterImpl();
    }
    DataParametersFormComponent.prototype.ngOnChanges = function (changes) {
        if (changes.editMode) {
            var newParameter = changes.newParameter;
            console.log('Previous parameter: ', newParameter.previousValue);
            console.log('New parameter: ', newParameter.currentValue);
            this.newParameter = newParameter.currentValue;
        }
        if (changes.editMode)
            this.editMode = changes.editMode.currentValue;
    };
    DataParametersFormComponent.prototype.addValueOption = function () {
        this.newParameter.valueOptions.push(new ValueOptionImpl());
    };
    DataParametersFormComponent.prototype.removeValueOption = function (valueOption) {
        this.newParameter.valueOptions =
            this.newParameter.valueOptions
                .filter(function (vo) { return vo !== valueOption; });
    };
    DataParametersFormComponent.prototype.onSubmitParameter = function () {
        //if ((this.newParameter.context & ParameterFilter.data) != 0)
        //    this.newParameter.number = this.parameters.filter(p => (p.context & ParameterFilter.data) != 0).length;
        //this.parameterService.create(this.scriptId, this.newParameter)
        //    .subscribe((p: Parameter) => {
        //        console.log(p);
        //        this.parameters.push(p);
        //    });
    };
    DataParametersFormComponent.prototype.update = function () {
        this.parameterService.update(this.scriptId, this.newParameter)
            .subscribe(function (p) {
            console.log(p);
        }, function (error) { return console.error(error); });
    };
    __decorate([
        Input(),
        __metadata("design:type", Boolean)
    ], DataParametersFormComponent.prototype, "editMode", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Number)
    ], DataParametersFormComponent.prototype, "scriptId", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], DataParametersFormComponent.prototype, "newParameter", void 0);
    DataParametersFormComponent = __decorate([
        Component({
            selector: 'app-data-parameters-form',
            templateUrl: './data-parameters-form.component.html',
            styleUrls: ['./data-parameters-form.component.css']
        }),
        __metadata("design:paramtypes", [ParameterService])
    ], DataParametersFormComponent);
    return DataParametersFormComponent;
}());
export { DataParametersFormComponent };
//# sourceMappingURL=data-parameters-form.component.js.map