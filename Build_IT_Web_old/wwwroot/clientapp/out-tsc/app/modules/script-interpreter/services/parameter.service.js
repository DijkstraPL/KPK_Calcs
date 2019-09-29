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
import { HttpClient } from '@angular/common/http';
import { TranslationService } from '../../../services/translation.service';
var ParameterService = /** @class */ (function () {
    function ParameterService(http, translationService) {
        this.http = http;
        this.translationService = translationService;
    }
    ParameterService.prototype.getParameters = function (scriptId, language) {
        return this.http.get('/api/scripts/' + scriptId + '/parameters/' + (language || this.translationService.getCurrentLanguage()));
    };
    ParameterService.prototype.create = function (scriptId, parameter) {
        return this.http.post('/api/scripts/' + scriptId + '/parameters', parameter);
    };
    ParameterService.prototype.update = function (scriptId, parameter) {
        return this.http.put('/api/scripts/' + scriptId + '/parameters/' + parameter.id, parameter);
    };
    ParameterService.prototype.delete = function (scriptId, parameterId) {
        return this.http.delete('/api/scripts/' + scriptId + '/parameters/' + parameterId);
    };
    ParameterService = __decorate([
        Injectable({ providedIn: 'root' }),
        __metadata("design:paramtypes", [HttpClient,
            TranslationService])
    ], ParameterService);
    return ParameterService;
}());
export { ParameterService };
//# sourceMappingURL=parameter.service.js.map