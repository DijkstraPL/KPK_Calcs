import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AppError } from '../../../common/errors/app-error';
import { BadInputError } from '../../../common/errors/bad-input-error';
import { NotFoundError } from '../../../common/errors/not-found-error';
import { TranslationService } from '../../../services/translation.service';
import { ICreateScriptCommand, CreateScriptCommand } from '../models/api/scripts/create-script-command';
import { Script } from '../models/interfaces/script';

@Injectable({ providedIn: 'root' })
export class ScriptService {

    constructor(private http: HttpClient,
        private translationService: TranslationService) {
    }

    getScripts(language?: string): Observable<Script[]> {
        return this.http.get<Script[]>('/api/scripts/' + (language || this.translationService.getCurrentLanguage()))
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }
    
    getScript(id: number, language?: string): Observable<Script> {
        return this.http.get<Script>('/api/scripts/' + id + '/' + (language || this.translationService.getCurrentLanguage()))
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    delete(id: number) {
        return this.http.delete<Script>('/api/scripts/' + id)
            .pipe(
                retry(1),
                catchError((error: Response) => {
                    if (error.status === 404)
                        return throwError(new NotFoundError(error));
                    return throwError(new AppError(error));
                })
            );
    }

    create(script: Script) {
        return this.http.post('/api/scripts', script)
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

    update(script: Script) {
        return this.http.put('/api/scripts/' + script.id, script)
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