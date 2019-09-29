import { Injectable, Inject, PLATFORM_ID } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';

@Injectable()
export class AuthService {
    authKey: string = "auth";
    clientId: string = "TestMakerFree";

    constructor(private http: HttpClient,
        @Inject(PLATFORM_ID) private platformId: any) {
    }

    // Przeprowadź logowanie
    login(username: string, password: string): Observable<boolean> {
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
    }

    // Spróbuj odświeżyć token
    refreshToken(): Observable<boolean> {
        var url = "api/token/auth";
        var data = {
            client_id: this.clientId,
            // Wymagane do zalogowania się przy użyciu nazwy użytkownika i hasła
            grant_type: "refresh_token",
            refresh_token: this.getAuth()!.refresh_token,
            // Oddzielona spacjami lista zakresów, dla których token będzie ważny
            scope: "offline_access profile email"
        };

        return this.getAuthFromServer(url, data);
    }

    // Pobierz z serwera tokeny (dostępowy i odświeżania)
    getAuthFromServer(url: string, data: any): Observable<boolean> {
        return this.http.post<TokenResponse>(url, data)
            .pipe(
                map((res: TokenResponse) => {
                    let token = res && res.token;
                    // Jeśli jest token, logowanie się udało
                    if (token) {
                        // Zapamiętaj nazwę użytkownika i tokeny
                        this.setAuth(res);
                        // Logowanie udane
                        return true;
                    }

                    // Logowanie nieudane
                    return Observable.throw('Unauthorized');
                }),
                catchError(error => {
                    return new Observable<any>(error);
                }));
    }

    // Przeprowadź wylogowanie
    logout(): boolean {
        this.setAuth(null);
        return true;
    }

    // Umieść dane o uwierzytelnieniu w localStorage lub usuń dane, jeśli przekazano NULL
    setAuth(auth: TokenResponse | null): boolean {
        if (auth) {
            localStorage.setItem(
                this.authKey,
                JSON.stringify(auth));
        }
        else {
            localStorage.removeItem(this.authKey);
        }
        return true;
    }

    // Pobiera obiekt z danymi uwierzytelnienia (lub zwraca NULL, jeśli nie istnieje)
    getAuth(): TokenResponse | null {
        var i = localStorage.getItem(this.authKey);
        if (i) {
            return JSON.parse(i);
        }
        else {
            return null;
        }
    }

    // Zwraca TRUE, jeśli użytkownik jest zalogowany lub FALSE w sytuacji przeciwnej
    isLoggedIn(): boolean {
        return localStorage.getItem(this.authKey) != null;
    }
} 
