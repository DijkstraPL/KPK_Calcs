import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { TranslationService } from '../../services/translation.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})

export class RegisterComponent {
    form: FormGroup;

    constructor(private router: Router,
        private fb: FormBuilder,
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {


        // Inicjalizacja formularza
        this.createForm();

    }

    createForm() {
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
    }

    onSubmit() {
        // Zbuduj tymczasowy obiekt z wartości z formularza
        var tempUser = <User>{};
        tempUser.Username = this.form.value.Username;
        tempUser.Email = this.form.value.Email;
        tempUser.Password = this.form.value.Password;
        tempUser.DisplayName = this.form.value.DisplayName;

        var url = this.baseUrl + "api/users";

        this.http
            .put<User>(url, tempUser)
            .subscribe(res => {
                if (res) {
                    var v = res;
                    console.log("Użytkownik " + v.Username + " został utworzony.");
                    // Przejdź do strony logowania
                    this.router.navigate(["login"]);
                }
                else {
                    // Rejestracja nieudana
                    this.form.setErrors({
                        "register": "Rejestracja nie powiodła się."
                    });
                }
            }, error => console.log(error));
    }

    onBack() {
        this.router.navigate(["home"]);
    }

    // Własny walidator porównujący wartości
    // Password i passwordConfirm
    passwordConfirmValidator(control: FormControl): any {

        // Pobierz obie kontrolki Controls
        let p = control.root.get('Password');
        let pc = control.root.get('PasswordConfirm');

        if (p && pc) {
            if (p.value !== pc.value) {
                pc.setErrors(
                    { "PasswordMismatch": true }
                );
            }
            else {
                pc.setErrors(null);
            }
        }
        return null;
    }

    // Pobierz FormControl
    getFormControl(name: string) {
        return this.form.get(name);
    }

    // Zwróć TRUE, jeśli element FormControl jest poprawny
    isValid(name: string) {
        var e = this.getFormControl(name);
        return e && e.valid;
    }

    // Zwróć TRUE, jeśli element FormControl uległ zmianie
    isChanged(name: string) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched);
    }

    // Zwróć TRUE, jeśli element FormControl nie jest poprawny po wprowadzeniu zmian
    hasError(name: string) {
        var e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    }

}
