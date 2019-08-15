var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Injectable, Inject, PLATFORM_ID } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
var AuthService = /** @class */ (function () {
    function AuthService(http, platformId) {
        this.http = http;
        this.platformId = platformId;
        this.authKey = "auth";
        this.clientId = "TestMakerFree";
    }
    // Przeprowadź logowanie
    AuthService.prototype.login = function (username, password) {
        var url = "api/token/auth";
        var data = {
            username: username,
            password: password,
            client_id: this.clientId,
            // Wymagane do zalogowania się przy użyciu nazwy użytkownika i hasła
            grant_type: "password",
            // Oddzielona spacjami lista zakresów, dla których token będzie ważny
            scope: "offline_access profile email"
        };
        return this.getAuthFromServer(url, data);
    };
    // Spróbuj odświeżyć token
    AuthService.prototype.refreshToken = function () {
        var url = "api/token/auth";
        var data = {
            client_id: this.clientId,
            // Wymagane do zalogowania się przy użyciu nazwy użytkownika i hasła
            grant_type: "refresh_token",
            refresh_token: this.getAuth().refresh_token,
            // Oddzielona spacjami lista zakresów, dla których token będzie ważny
            scope: "offline_access profile email"
        };
        return this.getAuthFromServer(url, data);
    };
    // Pobierz z serwera tokeny (dostępowy i odświeżania)
    AuthService.prototype.getAuthFromServer = function (url, data) {
        var _this = this;
        return this.http.post(url, data)
            .pipe(map(function (res) {
            var token = res && res.token;
            // Jeśli jest token, logowanie się udało
            if (token) {
                // Zapamiętaj nazwę użytkownika i tokeny
                _this.setAuth(res);
                // Logowanie udane
                return true;
            }
            // Logowanie nieudane
            return Observable.throw('Unauthorized');
        }), catchError(function (error) {
            return new Observable(error);
        }));
    };
    // Przeprowadź wylogowanie
    AuthService.prototype.logout = function () {
        this.setAuth(null);
        return true;
    };
    // Umieść dane o uwierzytelnieniu w localStorage lub usuń dane, jeśli przekazano NULL
    AuthService.prototype.setAuth = function (auth) {
        if (auth) {
            localStorage.setItem(this.authKey, JSON.stringify(auth));
        }
        else {
            localStorage.removeItem(this.authKey);
        }
        return true;
    };
    // Pobiera obiekt z danymi uwierzytelnienia (lub zwraca NULL, jeśli nie istnieje)
    AuthService.prototype.getAuth = function () {
        var i = localStorage.getItem(this.authKey);
        if (i) {
            return JSON.parse(i);
        }
        else {
            return null;
        }
    };
    // Zwraca TRUE, jeśli użytkownik jest zalogowany lub FALSE w sytuacji przeciwnej
    AuthService.prototype.isLoggedIn = function () {
        return localStorage.getItem(this.authKey) != null;
    };
    AuthService = __decorate([
        Injectable(),
        __param(1, Inject(PLATFORM_ID)),
        __metadata("design:paramtypes", [HttpClient, Object])
    ], AuthService);
    return AuthService;
}());
export { AuthService };
//# sourceMappingURL=auth.service.js.map