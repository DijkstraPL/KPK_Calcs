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
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../../models/enums/language';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterTranslationService } from '../../../../services/translations/parameter-translation.service';
var ParameterTranslationFormComponent = /** @class */ (function () {
    function ParameterTranslationFormComponent(parameterTranslationService, parameterService) {
        this.parameterTranslationService = parameterTranslationService;
        this.parameterService = parameterService;
        this.parametersTranslationsForm = new FormArray([
            new FormGroup({
                id: new FormControl('0'),
                parameterId: new FormControl('0'),
                description: new FormControl(),
                notes: new FormControl(),
                groupName: new FormControl(),
                language: new FormControl('0')
            })
        ]);
        this.languages = Language;
        this.matcher = new AppErrorStateMatcher();
    }
    Object.defineProperty(ParameterTranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    ParameterTranslationFormComponent.prototype.ngOnInit = function () {
        this.getParameters();
        this.getParametersTranslations();
    };
    ParameterTranslationFormComponent.prototype.getParametersTranslations = function () {
        var _this = this;
        this.parameterTranslationService.getParametersTranslation(this.translationData.scriptId, this.translationLanguage.value)
            .subscribe(function (parametersTranslations) {
            console.log(parametersTranslations);
            _this.parametersTranslationsForm.patchValue(parametersTranslations);
            console.log(_this.parametersTranslationsForm);
        });
    };
    ParameterTranslationFormComponent.prototype.getParameters = function () {
        var _this = this;
        this.parameterService.getParameters(this.translationData.scriptId, this.translationLanguage.value)
            .subscribe(function (parameters) {
            _this.parameters = parameters;
        });
    };
    __decorate([
        Input('scriptForm'),
        __metadata("design:type", FormGroup)
    ], ParameterTranslationFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Input('translationForm'),
        __metadata("design:type", FormGroup)
    ], ParameterTranslationFormComponent.prototype, "translationForm", void 0);
    __decorate([
        Input('defaultLanguage'),
        __metadata("design:type", Number)
    ], ParameterTranslationFormComponent.prototype, "defaultLanguage", void 0);
    __decorate([
        Input('translationData'),
        __metadata("design:type", Object)
    ], ParameterTranslationFormComponent.prototype, "translationData", void 0);
    ParameterTranslationFormComponent = __decorate([
        Component({
            selector: 'app-parameter-translation-form',
            templateUrl: './parameter-translation-form.component.html',
            styleUrls: ['./parameter-translation-form.component.scss']
        }),
        __metadata("design:paramtypes", [ParameterTranslationService,
            ParameterService])
    ], ParameterTranslationFormComponent);
    return ParameterTranslationFormComponent;
}());
export { ParameterTranslationFormComponent };
//# sourceMappingURL=parameter-translation-form.component.js.map