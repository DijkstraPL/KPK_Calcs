var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AppError } from '../../../common/errors/app-error';
import { BadInputError } from '../../../common/errors/bad-input-error';
import { NotFoundError } from '../../../common/errors/not-found-error';
import { TranslationService } from '../../../services/translation.service';
var ScriptService = /** @class */ (function () {
    function ScriptService(http, translationService) {
        this.http = http;
        this.translationService = translationService;
    }
    ScriptService.prototype.getScripts = function (language) {
        return this.http.get('/api/scripts/' + (language || this.translationService.getCurrentLanguage()))
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptService.prototype.getScript = function (id, language) {
        return this.http.get('/api/scripts/' + id + '/' + (language || this.translationService.getCurrentLanguage()))
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptService.prototype.delete = function (id) {
        return this.http.delete('/api/scripts/' + id)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptService.prototype.create = function (script) {
        return this.http.post('/api/scripts', script)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 400)
                return throwError(new BadInputError(error));
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptService.prototype.update = function (script) {
        return this.http.put('/api/scripts/' + script.id, script)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 400)
                return throwError(new BadInputError(error));
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ScriptService = __decorate([
        Injectable({ providedIn: 'root' }),
        __metadata("design:paramtypes", [HttpClient,
            TranslationService])
    ], ScriptService);
    return ScriptService;
}());
export { ScriptService };
//# sourceMappingURL=script.service.js.map