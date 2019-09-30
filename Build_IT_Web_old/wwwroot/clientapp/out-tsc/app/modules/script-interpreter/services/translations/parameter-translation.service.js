var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { AppError } from "../../../../common/errors/app-error";
import { NotFoundError } from "../../../../common/errors/not-found-error";
import { BadInputError } from "../../../../common/errors/bad-input-error";
var ParameterTranslationService = /** @class */ (function () {
    function ParameterTranslationService(http) {
        this.http = http;
    }
    ParameterTranslationService.prototype.getParametersTranslation = function (scriptId, language) {
        return this.http.get('/api/parametersTranslations/' + scriptId + '/' + language)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ParameterTranslationService.prototype.update = function (parameterTranslation) {
        return this.http.put('/api/parametersTranslations/' + parameterTranslation.id, parameterTranslation)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 400)
                return throwError(new BadInputError(error));
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ParameterTranslationService.prototype.create = function (parameterTranslation) {
        return this.http.post('/api/parametersTranslations', parameterTranslation)
            .pipe(retry(1), catchError(function (error) {
            if (error.status === 400)
                return throwError(new BadInputError(error));
            if (error.status === 404)
                return throwError(new NotFoundError(error));
            return throwError(new AppError(error));
        }));
    };
    ParameterTranslationService = __decorate([
        Injectable({ providedIn: 'root' }),
        __metadata("design:paramtypes", [HttpClient])
    ], ParameterTranslationService);
    return ParameterTranslationService;
}());
export { ParameterTranslationService };
//# sourceMappingURL=parameter-translation.service.js.map