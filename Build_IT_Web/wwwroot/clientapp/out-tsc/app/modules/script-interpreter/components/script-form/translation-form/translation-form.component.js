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
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';
import { ActivatedRoute } from '@angular/router';
import { Language } from '../../../models/enums/language';
import { ScriptTranslationService } from '../../../services/translations/script-translation.service';
import { ParameterService } from '../../../services/parameter.service';
var TranslationFormComponent = /** @class */ (function () {
    function TranslationFormComponent(scriptTranslationService, 
    // private parameterTranslationService: ParameterTranslationService,
    parameterService, route) {
        this.scriptTranslationService = scriptTranslationService;
        this.parameterService = parameterService;
        this.route = route;
        this.translationForm = new FormGroup({
            id: new FormControl('0'),
            scriptId: new FormControl(''),
            language: new FormControl('0', Validators.required),
            name: new FormControl('', Validators.maxLength(100)),
            description: new FormControl('', Validators.maxLength(500)),
            notes: new FormControl('', Validators.maxLength(1000))
        });
        this.languages = Language;
        this.matcher = new AppErrorStateMatcher();
    }
    Object.defineProperty(TranslationFormComponent.prototype, "originalName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "originalDescription", {
        get: function () {
            return this.scriptForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "originalNotes", {
        get: function () {
            return this.scriptForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "originalDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationId", {
        get: function () {
            return this.translationForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationScriptId", {
        get: function () {
            return this.translationForm.get('scriptId');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationName", {
        get: function () {
            return this.translationForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationDescription", {
        get: function () {
            return this.translationForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationNotes", {
        get: function () {
            return this.translationForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    TranslationFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.scriptId = +params['id'];
        });
        this.translationScriptId.setValue(this.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);
        this.getScriptTranslation(this.translationLanguage.value);
        this.getParameters();
        this.getParametersTranslations(this.translationLanguage.value);
    };
    TranslationFormComponent.prototype.onLanguageChange = function ($event) {
        this.getScriptTranslation($event.value);
    };
    TranslationFormComponent.prototype.getScriptTranslation = function (language) {
        var _this = this;
        this.scriptTranslationService.getScriptTranslation(this.scriptId, language)
            .subscribe(function (translation) {
            if (translation) {
                _this.translationForm.patchValue(translation);
                _this.editMode = true;
            }
            else
                _this.editMode = false;
        });
    };
    TranslationFormComponent.prototype.getParametersTranslations = function (language) {
        //this.parameterTranslationService
    };
    TranslationFormComponent.prototype.onScriptTranslationSubmit = function () {
        var _this = this;
        if (!this.editMode)
            this.scriptTranslationService.create(this.translationForm.value)
                .subscribe(function (scriptTranslation) {
                _this.translationForm.patchValue(scriptTranslation);
                _this.editMode = true;
            }, function (error) { throw error; });
        else
            this.scriptTranslationService.update(this.translationForm.value)
                .subscribe(function (scriptTranslation) { return _this.translationForm.patchValue(scriptTranslation); });
    };
    TranslationFormComponent.prototype.removeScriptTranslation = function () {
        var _this = this;
        var selectedLanguage = this.translationLanguage.value;
        this.scriptTranslationService.remove(this.translationId.value)
            .subscribe(function (scriptTranslation) {
            _this.translationForm.reset();
            _this.editMode = false;
            _this.translationScriptId.setValue(_this.scriptId);
            _this.translationLanguage.setValue(selectedLanguage);
        });
    };
    TranslationFormComponent.prototype.getParameters = function () {
        var _this = this;
        this.parameterService.getParameters(this.scriptId, this.originalDefaultLanguage.value).subscribe(function (parameters) {
            _this.parameters = parameters;
        }, function (error) { return console.error(error); });
    };
    __decorate([
        Input('defaultLanguage'),
        __metadata("design:type", Number)
    ], TranslationFormComponent.prototype, "defaultLanguage", void 0);
    __decorate([
        Input('scriptForm'),
        __metadata("design:type", FormGroup)
    ], TranslationFormComponent.prototype, "scriptForm", void 0);
    TranslationFormComponent = __decorate([
        Component({
            selector: 'app-translation-form',
            templateUrl: './translation-form.component.html',
            styleUrls: ['./translation-form.component.scss']
        }),
        __metadata("design:paramtypes", [ScriptTranslationService,
            ParameterService,
            ActivatedRoute])
    ], TranslationFormComponent);
    return TranslationFormComponent;
}());
export { TranslationFormComponent };
//# sourceMappingURL=translation-form.component.js.map