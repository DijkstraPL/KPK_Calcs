import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { AppError } from "../../../../common/errors/app-error";
import { NotFoundError } from "../../../../common/errors/not-found-error";
import { Language } from "../../models/enums/language";
import { ParameterTranslation } from "../../models/interfaces/translations/parameterTranslation";
import { BadInputError } from "../../../../common/errors/bad-input-error";


@Injectable({ providedIn: 'root' })
export class ParameterTranslationService {

    constructor(private http: HttpClient) {
    }

    getParametersTranslation(scriptId: number, language: Language): Observable<ParameterTranslation[]> {
        return this.http.get<ParameterTranslation[]>('/api/parametersTranslations/' + scriptId + '/' + language)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    update(parameterTranslation: ParameterTranslation) {
        return this.http.put('/api/parametersTranslations/' + parameterTranslation.id, parameterTranslation)
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

    create(parameterTranslation: ParameterTranslation) {
        return this.http.post('/api/parametersTranslations', parameterTranslation)
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
  
}