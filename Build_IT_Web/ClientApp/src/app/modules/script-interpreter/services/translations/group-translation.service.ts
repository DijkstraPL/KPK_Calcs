import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { AppError } from "../../../../common/errors/app-error";
import { BadInputError } from "../../../../common/errors/bad-input-error";
import { NotFoundError } from "../../../../common/errors/not-found-error";
import { Language } from "../../models/enums/language";
import { GroupTranslation } from "../../models/interfaces/translations/groupTranslation";


@Injectable({ providedIn: 'root' })
export class GroupTranslationService {

    constructor(private http: HttpClient) {
    }

    getGroupsTranslation(scriptId: number, language: Language): Observable<GroupTranslation[]> {
        return this.http.get<GroupTranslation[]>('/api/groupsTranslations/' + scriptId + '/' + language)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    update(groupTranslation: GroupTranslation) {
        return this.http.put('/api/groupsTranslations/' + groupTranslation.id, groupTranslation)
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

    create(groupTranslation: GroupTranslation) {
        return this.http.post('/api/groupsTranslations', groupTranslation)
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
