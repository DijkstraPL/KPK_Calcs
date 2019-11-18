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
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Language } from '../../../../models/enums/language';
import { ScriptTranslationService } from '../../../../services/translations/script-translation.service';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
var ScriptTranslationFormComponent = /** @class */ (function () {
    function ScriptTranslationFormComponent(scriptTranslationService, route) {
        this.scriptTranslationService = scriptTranslationService;
        this.route = route;
        this.languages = Language;
        this.matcher = new AppErrorStateMatcher();
    }
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalDescription", {
        get: function () {
            return this.scriptForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalNotes", {
        get: function () {
            return this.scriptForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "originalDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationId", {
        get: function () {
            return this.translationForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationScriptId", {
        get: function () {
            return this.translationForm.get('scriptId');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationName", {
        get: function () {
            return this.translationForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationDescription", {
        get: function () {
            return this.translationForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationNotes", {
        get: function () {
            return this.translationForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptTranslationFormComponent.prototype, "translationLanguage", {
        get: function () {
            return this.translationForm.get('language');
        },
        enumerable: true,
        configurable: true
    });
    ScriptTranslationFormComponent.prototype.ngOnInit = function () {
        this.translationScriptId.setValue(this.translationData.scriptId);
        if (this.defaultLanguage == this.languages.english)
            this.translationLanguage.setValue(this.languages.polish);
        else
            this.translationLanguage.setValue(this.languages.english);
        this.getScriptTranslation(this.translationLanguage.value);
    };
    ScriptTranslationFormComponent.prototype.onLanguageChange = function ($event) {
        this.getScriptTranslation($event.value);
    };
    ScriptTranslationFormComponent.prototype.getScriptTranslation = function (language) {
        var _this = this;
        this.scriptTranslationService.getScriptTranslation(this.translationData.scriptId, language)
            .subscribe(function (translation) {
            if (translation) {
                _this.translationForm.patchValue(translation);
                _this.translationData.editMode = true;
            }
            else
                _this.translationData.editMode = false;
        });
    };
    __decorate([
        Input('scriptForm'),
        __metadata("design:type", FormGroup)
    ], ScriptTranslationFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Input('translationForm'),
        __metadata("design:type", FormGroup)
    ], ScriptTranslationFormComponent.prototype, "translationForm", void 0);
    __decorate([
        Input('defaultLanguage'),
        __metadata("design:type", Number)
    ], ScriptTranslationFormComponent.prototype, "defaultLanguage", void 0);
    __decorate([
        Input('translationData'),
        __metadata("design:type", Object)
    ], ScriptTranslationFormComponent.prototype, "translationData", void 0);
    ScriptTranslationFormComponent = __decorate([
        Component({
            selector: 'app-script-translation-form',
            templateUrl: './script-translation-form.component.html',
            styleUrls: ['./script-translation-form.component.scss']
        }),
        __metadata("design:paramtypes", [ScriptTranslationService,
            ActivatedRoute])
    ], ScriptTranslationFormComponent);
    return ScriptTranslationFormComponent;
}());
export { ScriptTranslationFormComponent };
//# sourceMappingURL=script-translation-form.component.js.map