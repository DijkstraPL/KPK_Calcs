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
var ScriptService = /** @class */ (function () {
    function ScriptService(http) {
        this.http = http;
    }
    ScriptService.prototype.getScripts = function () {
        return this.http.get('/api/scripts');
    };
    ScriptService.prototype.getScript = function (id) {
        return this.http.get('/api/scripts/' + id);
    };
    ScriptService.prototype.deleteScript = function (id) {
        return this.http.delete('/api/scripts/' + id);
    };
    ScriptService.prototype.getEditableParameters = function (scriptId) {
        return this.http.get('/api/scripts/' + scriptId + '/editable_parameters');
    };
    ScriptService.prototype.getParameters = function (scriptId) {
        return this.http.get('/api/scripts/' + scriptId + '/parameters');
    };
    ScriptService.prototype.create = function (script) {
        return this.http.post('/api/scripts', script);
    };
    ScriptService.prototype.update = function (script) {
        return this.http.put('/api/scripts/' + script.id, script);
    };
    ScriptService.prototype.calculate = function (scriptId, parameters) {
        return this.http.put('/api/scripts/' + scriptId + '/calculate', parameters);
    };
    ScriptService = __decorate([
        Injectable({ providedIn: 'root' }),
        __metadata("design:paramtypes", [HttpClient])
    ], ScriptService);
    return ScriptService;
}());
export { ScriptService };
//# sourceMappingURL=script.service.js.map