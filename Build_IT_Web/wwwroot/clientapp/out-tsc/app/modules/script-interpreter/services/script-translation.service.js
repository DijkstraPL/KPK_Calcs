var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TranslationService } from "../../../services/translation.service";
import { throwError } from "rxjs";
import { retry, catchError } from "rxjs/operators";
import { NotFoundError } from "../../../common/errors/not-found-error";
import { AppError } from "../../../common/errors/app-error";
import { BadInputError } from "../../../common/errors/bad-input-error";
var ScriptTranslationService = /** @class */ (function () {
    function ScriptTranslationService(http, translationService) {
        this.http = http;
        this.translationService = translationService;
    }
    ScriptTranslationService.prototype.getScriptTranslation = function (scriptId, language) {
        return this.http.get('/api/scriptsTranslations/' + scriptId + '/' + language)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptTranslationService.prototype.create = function (scriptTranslation) {
        return this.http.post('/api/scriptsTranslations', scriptTranslation)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 400)
                return throwError(new BadInputError(error));
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptTranslationService.prototype.update = function (scriptTranslation) {
        return this.http.put('/api/scriptsTranslations/' + scriptTranslation.id, scriptTranslation)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 400)
                return throwError(new BadInputError(error));
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptTranslationService = __decorate([
        Injectable({ providedIn: 'root' }),
        __metadata("design:paramtypes", [HttpClient,
            TranslationService])
    ], ScriptTranslationService);
    return ScriptTranslationService;
}());
export { ScriptTranslationService };
//# sourceMappingURL=script-translation.service.js.map