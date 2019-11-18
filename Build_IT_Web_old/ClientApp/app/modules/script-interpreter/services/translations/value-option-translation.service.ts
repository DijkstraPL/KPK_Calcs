import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { AppError } from "../../../../common/errors/app-error";
import { NotFoundError } from "../../../../common/errors/not-found-error";
import { Language } from "../../models/enums/language";
import { ParameterTranslation } from "../../models/interfaces/translations/parameterTranslation";
import { BadInputError } from "../../../../common/errors/bad-input-error";
import { ValueOptionTranslation } from "../../models/interfaces/translations/valueOptionTranslation";


@Injectable({ providedIn: 'root' })
export class ValueOptionTranslationService {

    constructor(private http: HttpClient) {
    }

    getValueOptionsTranslations(parameterId: number, language: Language): Observable<ValueOptionTranslation[]> {
        return this.http.get<ValueOptionTranslation[]>('/api/valueOptionsTranslations/' + parameterId + '/' + language)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    update(valueOptionTranslation: ValueOptionTranslation) {
        return this.http.put('/api/valueOptionsTranslations/' + valueOptionTranslation.id, valueOptionTranslation)
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

    create(valueOptionTranslation: ValueOptionTranslation) {
        return this.http.post('/api/valueOptionsTranslations', valueOptionTranslation)
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