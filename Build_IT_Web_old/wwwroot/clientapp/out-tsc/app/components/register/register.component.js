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
import { HttpClient } from '@angular/common/http';
var RegisterComponent = /** @class */ (function () {
    function RegisterComponent(router, fb, http, baseUrl) {
        this.router = router;
        this.fb = fb;
        this.http = http;
        this.baseUrl = baseUrl;
        // Inicjalizacja formularza
        this.createForm();
    }
    RegisterComponent.prototype.createForm = function () {
        this.form = this.fb.group({
            Username: ['', Validators.required],
            Email: ['',
                [Validators.required,
                    Validators.email]
            ],
            Password: ['', Validators.required],
            PasswordConfirm: ['', Validators.required],
            DisplayName: ['', Validators.required]
        }, {
            validator: this.passwordConfirmValidator
        });
    };
    RegisterComponent.prototype.onSubmit = function () {
        var _this = this;
        // Zbuduj tymczasowy obiekt z wartości z formularza
        var tempUser = {};
        tempUser.Username = this.form.value.Username;
        tempUser.Email = this.form.value.Email;
        tempUser.Password = this.form.value.Password;
        tempUser.DisplayName = this.form.value.DisplayName;
        var url = this.baseUrl + "api/users";
        this.http
            .put(url, tempUser)
            .subscribe(function (res) {
            if (res) {
                var v = res;
                console.log("Użytkownik " + v.Username + " został utworzony.");
                // Przejdź do strony logowania
                _this.router.navigate(["login"]);
            }
            else {
                // Rejestracja nieudana
                _this.form.setErrors({
                    "register": "Rejestracja nie powiodła się."
                });
            }
        }, function (error) { return console.log(error); });
    };
    RegisterComponent.prototype.onBack = function () {
        this.router.navigate(["home"]);
    };
    // Własny walidator porównujący wartości
    // Password i passwordConfirm
    RegisterComponent.prototype.passwordConfirmValidator = function (control) {
        // Pobierz obie kontrolki Controls
        var p = control.root.get('Password');
        var pc = control.root.get('PasswordConfirm');
        if (p && pc) {
            if (p.value !== pc.value) {
                pc.setErrors({ "PasswordMismatch": true });
            }
            else {
                pc.setErrors(null);
            }
        }
        return null;
    };
    // Pobierz FormControl
    RegisterComponent.prototype.getFormControl = function (name) {
        return this.form.get(name);
    };
    // Zwróć TRUE, jeśli element FormControl jest poprawny
    RegisterComponent.prototype.isValid = function (name) {
        var e = this.getFormControl(name);
        return e && e.valid;
    };
    // Zwróć TRUE, jeśli element FormControl uległ zmianie
    RegisterComponent.prototype.isChanged = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    };
    // Zwróć TRUE, jeśli element FormControl nie jest poprawny po wprowadzeniu zmian
    RegisterComponent.prototype.hasError = function (name) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    };
    RegisterComponent = __decorate([
        Component({
            selector: 'app-register',
            templateUrl: './register.component.html',
            styleUrls: ['./register.component.scss']
        }),
        __param(3, Inject('BASE_URL')),
        __metadata("design:paramtypes", [Router,
            FormBuilder,
            HttpClient, String])
    ], RegisterComponent);
    return RegisterComponent;
}());
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map