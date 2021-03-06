﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Parameter } from '../models/interfaces/parameter';
import { Observable } from 'rxjs';
import { TranslationService } from '../../../services/translation.service';

@Injectable({ providedIn: 'root' })
export class ParameterService {
    constructor(private http: HttpClient,
        private translationService: TranslationService) {

    }
        
    getParameters(scriptId: number, language?: string): Observable<Parameter[]> {
        return this.http.get<Parameter[]>('/api/scripts/' + scriptId + '/parameters/' + (language || this.translationService.getCurrentLanguage()));
    }

    create(scriptId: number, parameter: Parameter) {
        return this.http.post('/api/scripts/' + scriptId + '/parameters', parameter);
    }

    update(scriptId: number, parameter: Parameter) {
        return this.http.put('/api/scripts/' + scriptId + '/parameters/' + parameter.id, parameter);
    }

    delete(scriptId: number, parameterId: number): Observable<Parameter> {
        return this.http.delete<Parameter>('/api/scripts/' + scriptId + '/parameters/' + parameterId);
    }
}