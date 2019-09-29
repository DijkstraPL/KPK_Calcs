import { Injectable, Inject, PLATFORM_ID, Injector } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHandler, HttpResponse, HttpEvent, HttpRequest, HttpInterceptor } from "@angular/common/http";
import { Observable } from "rxjs";
import { AuthService } from "./auth.service";
import { Router } from "@angular/router";
import { tap, catchError, flatMap } from 'rxjs/operators';

@Injectable()
export class AuthResponseInterceptor implements HttpInterceptor {

    currentRequest: HttpRequest<any>;
    auth: AuthService;

    constructor(
        private injector: Injector,
        private router: Router
    ) { }

    intercept(
        request: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {

        this.auth = this.injector.get(AuthService);
        var token = (this.auth.isLoggedIn()) ? this.auth.getAuth()!.token : null;

        if (token) {
            // Zapamiętaj aktualne żądanie
            this.currentRequest = request;

            return next.handle(request)
                .pipe(
                tap((event: HttpEvent<any>) => {
                    if (event instanceof HttpResponse) {
                        // Nic nie rób
                    }
                }), catchError(error => {
                    return this.handleError(error, next)
                }));
        }
        else {
            return next.handle(request);
        }
    }

    handleError(err: any, next: HttpHandler) {
        if (err instanceof HttpErrorResponse) {
            if (err.status === 401) {
                // Token JWT mógł przestać być ważny:
                // spróbuj otrzymać nowy za pomocą tokena odświeżania
                console.log("Token nieważny. Próba odświeżenia...");

                // Zapamiętaj aktualne żądanie jako poprzednie
                var previousRequest = this.currentRequest;

                // Za poniższy kod dziękuję użytkownikowi @mattjones61
                return this.auth.refreshToken()
                    .pipe(
                        flatMap((refreshed) => {
                            var token = (this.auth.isLoggedIn()) ? this.auth.getAuth()!.token : null;
                            if (token) {
                                previousRequest = previousRequest.clone({
                                    setHeaders: { Authorization: `Bearer ${token}` }
                                });
                                console.log("Reset tokena z nagłówka");
                            }
                            return next.handle(previousRequest);
                        }));
            }
        }
        return Observable.throw(err);
    }
}
