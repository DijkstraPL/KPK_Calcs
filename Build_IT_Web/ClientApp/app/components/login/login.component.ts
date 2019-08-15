import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent {
    title: string;
    form: FormGroup;

    constructor(private router: Router,
        private fb: FormBuilder,
        private authService: AuthService,
        @Inject('BASE_URL') private baseUrl: string) {

        this.title = "Zaloguj się";
        this.createForm();

    }

    createForm() {
        this.form = this.fb.group({
            Username: ['', Validators.required],
            Password: ['', Validators.required]
        });
    }

    onSubmit() {
        var url = this.baseUrl + "api/token/auth";
        var username = this.form.value.Username;
        var password = this.form.value.Password;

        this.authService.login(username, password)
            .subscribe(res => {
                // Logowanie udane

                // Wyświetl dane logowania w okienku alert.
                // WAŻNE: usuń po zakończeniu testu
                alert("Logowanie udane! "
                    + "NAZWA UŻYTKOWNIKA: "
                    + username
                    + " TOKEN: "
                    + this.authService.getAuth()!.token
                );

                this.router.navigate(["home"]);
            },
                err => {
                    // Logowanie nieudane
                    console.log(err);
                    this.form.setErrors({
                        "auth": "Niepoprawna nazwa użytkownika lub hasło."
                    });
                });
    }

    onBack() {
        this.router.navigate(["home"]);
    }

    getFormControl(name: string) {
        return this.form.get(name);
    }

    isValid(name: string) {
        var e = this.getFormControl(name);
        return e && e.valid;
    }

    isChanged(name: string) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    }

    hasError(name: string) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    }
}