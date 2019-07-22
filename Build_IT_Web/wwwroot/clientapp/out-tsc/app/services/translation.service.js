var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subject, of } from 'rxjs';
var TranslationService = /** @class */ (function () {
    function TranslationService(translate) {
        this.translate = translate;
        this.languages = ['en', 'pl'];
        this.onLanguageChanged = new Subject();
        this.languageChanged$ = this.onLanguageChanged.asObservable();
        this.addLanguages(this.languages);
        this.setDefaultLanguage('en');
    }
    TranslationService.prototype.addLanguages = function (lang) {
        this.translate.addLangs(lang);
    };
    TranslationService.prototype.setDefaultLanguage = function (lang) {
        this.translate.setDefaultLang(lang);
    };
    TranslationService.prototype.getDefaultLanguage = function () {
        return this.translate.defaultLang;
    };
    TranslationService.prototype.getBrowserLanguage = function () {
        return this.translate.getBrowserLang();
    };
    TranslationService.prototype.getCurrentLanguage = function () {
        return this.translate.currentLang;
    };
    TranslationService.prototype.getLoadedLanguages = function () {
        return this.translate.langs;
    };
    TranslationService.prototype.useBrowserLanguage = function () {
        var browserLang = this.getBrowserLanguage();
        if (browserLang.match(/en|pl/)) {
            this.changeLanguage(browserLang);
            return browserLang;
        }
    };
    TranslationService.prototype.useDefaultLangage = function () {
        return this.changeLanguage(null);
    };
    TranslationService.prototype.changeLanguage = function (language) {
        var _this = this;
        if (!language) {
            language = this.getDefaultLanguage();
        }
        if (language != this.translate.currentLang) {
            setTimeout(function () {
                _this.translate.use(language);
                _this.onLanguageChanged.next(language);
            });
        }
        return language;
    };
    TranslationService.prototype.getTranslation = function (key, interpolateParams) {
        return this.translate.instant(key, interpolateParams);
    };
    TranslationService.prototype.getTranslationAsync = function (key, interpolateParams) {
        return this.translate.get(key, interpolateParams);
    };
    TranslationService.LanguageCodes = [{ 'en': 0 }, { 'pl': 1 }];
    TranslationService = __decorate([
        Injectable({
            providedIn: 'root',
        }),
        __metadata("design:paramtypes", [TranslateService])
    ], TranslationService);
    return TranslationService;
}());
export { TranslationService };
var TranslateLanguageLoader = /** @class */ (function () {
    function TranslateLanguageLoader() {
    }
    TranslateLanguageLoader.prototype.getTranslation = function (lang) {
        switch (lang) {
            case 'en':
                return of(require('../../assets/locale/en.json'));
            case 'pl':
                return of(require('../../assets/locale/pl.json'));
            default:
        }
    };
    return TranslateLanguageLoader;
}());
export { TranslateLanguageLoader };
//# sourceMappingURL=translation.service.js.map