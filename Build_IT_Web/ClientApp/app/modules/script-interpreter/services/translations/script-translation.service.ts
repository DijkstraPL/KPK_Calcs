import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TranslationService } from "../../../../services/translation.service";
import { Observable, throwError } from "rxjs";
import { ScriptTranslation } from "../../models/interfaces/translations/scriptTranslation";
import { Language } from "../../models/enums/language";
import { retry, catchError } from "rxjs/operators";
import { NotFoundError } from "../../../../common/errors/not-found-error";
import { AppError } from "../../../../common/errors/app-error";
import { BadInputError } from "../../../../common/errors/bad-input-error";


@Injectable({ providedIn: 'root' })
export class ScriptTranslationService {

    constructor(private http: HttpClient,
        private translationService: TranslationService) {
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