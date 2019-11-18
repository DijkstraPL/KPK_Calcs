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
import { Component, Inject } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(router, fb, authService, bottomSheetRef, baseUrl) {
        this.router = router;
        this.fb = fb;
        this.authService = authService;
        this.bottomSheetRef = bottomSheetRef;
        this.baseUrl = baseUrl;
        this.createForm();
    }
    Object.defineProperty(LoginComponent.prototype, "username", {
        get: function () {
            return this.form.get('Username');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(LoginComponent.prototype, "password", {
        get: function () {
            return this.form.get('Password');
        },
        enumerable: true,
        configurable: true
    });
    LoginComponent.prototype.createForm = function () {
        this.form = this.fb.group({
            Username: ['', Validators.required],
            Password: ['', Validators.required]
        });
    };
    LoginComponent.prototype.onSubmit = function () {
        var _this = this;
        var url = this.baseUrl + "api/token/auth";
        var username = this.form.value.Username;
        var password = this.form.value.Password;
        this.authService.login(username, password)
            .subscribe(function (res) {
            // Logowanie udane
            // Wyświetl dane logowania w okienku alert.
            // WAŻNE: usuń po zakończeniu testu
            alert("Logowanie udane! "
                + "NAZWA UŻYTKOWNIKA: "
                + username
                + " TOKEN: "
                + _this.authService.getAuth().token);
            _this.bottomSheetRef.dismiss();
            _this.router.navigate(["home"]);
        }, function (err) {
            // Logowanie nieudane
            console.log(err);
            _this.form.setErrors({
                "auth": "Niepoprawna nazwa użytkownika lub hasło."
            });
        });
    };
    LoginComponent.prototype.dismiss = function () {
        this.bottomSheetRef.dismiss();
    };
    LoginComponent.prototype.onBack = function () {
        this.bottomSheetRef.dismiss();
        this.router.navigate(["home"]);
    };
    LoginComponent.prototype.getFormControl = function (name) {
        return this.form.get(name);
    };
    LoginComponent.prototype.isValid = function (name) {
        var e = this.getFormControl(name);
        return e && e.valid;
    };
    LoginComponent.prototype.isChanged = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    };
    LoginComponent.prototype.hasError = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    };
    LoginComponent = __decorate([
        Component({
            selector: 'app-login',
            templateUrl: './login.component.html',
            styleUrls: ['./login.component.scss']
        }),
        __param(4, Inject('BASE_URL')),
        __metadata("design:paramtypes", [Router,
            FormBuilder,
            AuthService,
            MatBottomSheetRef, String])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map