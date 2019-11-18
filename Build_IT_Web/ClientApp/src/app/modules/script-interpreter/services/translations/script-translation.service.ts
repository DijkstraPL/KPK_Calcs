import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { AppError } from "../../../../common/errors/app-error";
import { BadInputError } from "../../../../common/errors/bad-input-error";
import { NotFoundError } from "../../../../common/errors/not-found-error";
import { Language } from "../../models/enums/language";
import { ScriptTranslation } from "../../models/interfaces/translations/scriptTranslation";


@Injectable({ providedIn: 'root' })
export class ScriptTranslationService {

    constructor(private http: HttpClient) {
    }

    getScriptTranslation(scriptId: number, language: Language): Observable<ScriptTranslation> {
        return this.http.get<ScriptTranslation>('/api/scriptsTranslations/' + scriptId + '/' + language)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    create(scriptTranslation: ScriptTranslation) {
        return this.http.post('/api/scriptsTranslations', scriptTranslation)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 400)
                        return throwError(new BadInputError(error));
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    update(scriptTranslation: ScriptTranslation) {
        return this.http.put('/api/scriptsTranslations/' + scriptTranslation.id, scriptTranslation)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 400)
                        return throwError(new BadInputError(error));
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    remove(id: number) {
        return this.http.delete<ScriptTranslation>('/api/scriptsTranslations/' + id)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }
}