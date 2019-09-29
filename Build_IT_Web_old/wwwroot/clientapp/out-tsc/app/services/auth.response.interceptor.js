var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable, Injector } from "@angular/core";
import { HttpErrorResponse, HttpResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";
import { Router } from "@angular/router";
import { tap, catchError, flatMap } from 'rxjs/operators';
var AuthResponseInterceptor = /** @class */ (function () {
    function AuthResponseInterceptor(injector, router) {
        this.injector = injector;
        this.router = router;
    }
    AuthResponseInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        this.auth = this.injector.get(AuthService);
        var token = (this.auth.isLoggedIn()) ? this.auth.getAuth().token : null;
        if (token) {
            // Zapamiętaj aktualne żądanie
            this.currentRequest = request;
            return next.handle(request)
                .pipe(tap(function (event) {
                if (event instanceof HttpResponse) {
                    // Nic nie rób
                }
            }), catchError(function (error) {
                return _this.handleError(error, next);
            }));
        }
        else {
            return next.handle(request);
        }
    };
    AuthResponseInterceptor.prototype.handleError = function (err, next) {
        var _this = this;
        if (err instanceof HttpErrorResponse) {
            if (err.status === 401) {
                // Token JWT mógł przestać być ważny:
                // spróbuj otrzymać nowy za pomocą tokena odświeżania
                console.log("Token nieważny. Próba odświeżenia...");
                // Zapamiętaj aktualne żądanie jako poprzednie
                var previousRequest = this.currentRequest;
                // Za poniższy kod dziękuję użytkownikowi @mattjones61
                return this.auth.refreshToken()
                    .pipe(flatMap(function (refreshed) {
                    var token = (_this.auth.isLoggedIn()) ? _this.auth.getAuth().token : null;
                    if (token) {
                        previousRequest = previousRequest.clone({
                            setHeaders: { Authorization: "Bearer " + token }
                        });
                        console.log("Reset tokena z nagłówka");
                    }
                    return next.handle(previousRequest);
                }));
            }
        }
        return Observable.throw(err);
    };
    AuthResponseInterceptor = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [Injector,
            Router])
    ], AuthResponseInterceptor);
    return AuthResponseInterceptor;
}());
export { AuthResponseInterceptor };
//# sourceMappingURL=auth.response.interceptor.js.map