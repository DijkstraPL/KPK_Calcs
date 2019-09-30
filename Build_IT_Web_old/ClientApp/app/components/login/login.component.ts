import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormBuilder, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { TranslationService } from '../../services/translation.service';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent {
    form: FormGroup;

    get username(): AbstractControl {
        return this.form.get('Username');
    }
    get password(): AbstractControl {
        return this.form.get('Password');
    }


    constructor(private router: Router,
        private fb: FormBuilder,
        private authService: AuthService,
        private bottomSheetRef: MatBottomSheetRef<LoginComponent>,
        @Inject('BASE_URL') private baseUrl: string) {

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

                this.bottomSheetRef.dismiss();
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

    dismiss() {
        this.bottomSheetRef.dismiss();
    }

    onBack() {
        this.bottomSheetRef.dismiss();
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