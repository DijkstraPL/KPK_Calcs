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
import { forkJoin } from 'rxjs';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../../models/enums/language';
import { ParameterService } from '../../../../services/parameter.service';
import { ParameterTranslationService } from '../../../../services/translations/parameter-translation.service';
import { ValueOptionTranslationService } from '../../../../services/translations/value-option-translation.service';
var ParameterTranslationFormComponent = /** @class */ (function () {
    function ParameterTranslationFormComponent(parameterTranslationService, valueOptionTranslationService, parameterService) {
        this.parameterTranslationService = parameterTranslationService;
        this.valueOptionTranslationService = valueOptionTranslationService;
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
        this.mappedParameters = [];
    }
    Object.defineProperty(ParameterTranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    ParameterTranslationFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        var parameters$ = this.getParameters();
        var parametersTranslations$ = this.getParametersTranslations();
        forkJoin([parameters$, parametersTranslations$]).subscribe(function (results) {
            _this.parameters = results[0];
            results[1].forEach(function (pt) { return _this.parametersTranslationsForm.push(new FormGroup({
                id: new FormControl(pt.id),
                parameterId: new FormControl(pt.parameterId),
                description: new FormControl(pt.description),
                notes: new FormControl(pt.notes),
                groupName: new FormControl(pt.groupName),
                language: new FormControl(pt.language)
            })); });
            _this.setMappedParameters();
        });
    };
    ParameterTranslationFormComponent.prototype.setMappedParameters = function () {
        var _this = this;
        this.mappedParameters = [];
        var parametersTranslation = this.parametersTranslationsForm.value;
        this.parameters.forEach(function (p) {
            var mappedParameter = {
                parameter: p, translation: parametersTranslation.find(function (pt) { return pt.parameterId == p.id; }) ||
                    new FormGroup({
                        id: new FormControl('0'),
                        parameterId: new FormControl(p.id),
                        description: new FormControl(''),
                        notes: new FormControl(''),
                        groupName: new FormControl(''),
                        language: new FormControl(_this.translationLanguage.value)
                    }).value,
                valueOptions: []
            };
            _this.mappedParameters.push(mappedParameter);
        });
        this.setValueOptions();
    };
    ParameterTranslationFormComponent.prototype.setValueOptions = function () {
        var _this = this;
        this.mappedParameters.forEach(function (mp) {
            _this.valueOptionTranslationService.getValueOptionsTranslations(mp.parameter.id, _this.translationLanguage.value)
                .subscribe(function (vot) {
                mp.parameter.valueOptions.forEach(function (vo) {
                    mp.valueOptions.push({
                        origin: vo, translation: vot.find(function (v) { return v.valueOptionId == vo.id; }) || new FormGroup({
                            id: new FormControl(0),
                            valueOptionId: new FormControl(vo.id),
                            name: new FormControl(''),
                            description: new FormControl(''),
                            language: new FormControl(_this.translationLanguage.value)
                        }).value
                    });
                });
            });
        });
    };
    ParameterTranslationFormComponent.prototype.getParametersTranslations = function () {
        return this.parameterTranslationService.getParametersTranslation(this.translationData.scriptId, this.translationLanguage.value);
    };
    ParameterTranslationFormComponent.prototype.getParameters = function () {
        return this.parameterService.getParameters(this.translationData.scriptId, this.translationLanguage.value);
    };
    ParameterTranslationFormComponent.prototype.parametersSubmit = function () {
        var _this = this;
        this.mappedParameters.forEach(function (mp) {
            if (mp.translation.id == 0 && mp.translation.description)
                _this.createParameterTranslation(mp.translation);
            else if (mp.translation.description)
                _this.updateParameterTranslation(mp.translation);
            mp.valueOptions.forEach(function (vo) {
                if (vo.translation.id == 0 && (vo.translation.name || vo.translation.description))
                    _this.createValueOptionTranslation(vo.translation);
                else if (vo.translation.name || vo.translation.description)
                    _this.updateValueOptionTranslation(vo.translation);
            });
        });
    };
    ParameterTranslationFormComponent.prototype.updateValueOptionTranslation = function (valueOptionTranslation) {
        this.valueOptionTranslationService.update(valueOptionTranslation)
            .subscribe(function (vot) { });
    };
    ParameterTranslationFormComponent.prototype.createValueOptionTranslation = function (valueOptionTranslation) {
        this.valueOptionTranslationService.create(valueOptionTranslation)
            .subscribe(function (vot) { });
    };
    ParameterTranslationFormComponent.prototype.updateParameterTranslation = function (parameterTranslation) {
        var _this = this;
        this.parameterTranslationService.update(parameterTranslation)
            .subscribe(function (updatedTranslation) {
            _this.parametersTranslationsForm.clear();
            _this.parametersTranslationsForm.push(new FormGroup({
                id: new FormControl(updatedTranslation.id),
                parameterId: new FormControl(updatedTranslation.parameterId),
                description: new FormControl(updatedTranslation.description),
                notes: new FormControl(updatedTranslation.notes),
                groupName: new FormControl(updatedTranslation.groupName),
                language: new FormControl(updatedTranslation.language)
            }));
        });
    };
    ParameterTranslationFormComponent.prototype.createParameterTranslation = function (parameterTranslation) {
        var _this = this;
        this.parameterTranslationService.create(parameterTranslation)
            .subscribe(function (newTranslation) {
            _this.parametersTranslationsForm.clear();
            _this.parametersTranslationsForm.push(new FormGroup({
                id: new FormControl(newTranslation.id),
                parameterId: new FormControl(newTranslation.parameterId),
                description: new FormControl(newTranslation.description),
                notes: new FormControl(newTranslation.notes),
                groupName: new FormControl(newTranslation.groupName),
                language: new FormControl(newTranslation.language)
            }));
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
            ValueOptionTranslationService,
            ParameterService])
    ], ParameterTranslationFormComponent);
    return ParameterTranslationFormComponent;
}());
export { ParameterTranslationFormComponent };
//# sourceMappingURL=parameter-translation-form.component.js.map