import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Parameter } from '../models/interfaces/parameter';
import { Observable } from 'rxjs';
import { TranslationService } from '../../../services/translation.service';
import { TestData } from '../models/interfaces/testData';
import { RangeOfParameters } from '../models/rangeOfParameters';

@Injectable({ providedIn: 'root' })
export class CalculationService {
    constructor(private http: HttpClient,
        private translationService: TranslationService) {

    }
    
    calculate(scriptId: number, parameters: Parameter[], language?: string): Observable<Parameter[]> {
        return this.http.post<Parameter[]>('/api/scripts/' + scriptId + '/calculate/' + (language || this.translationService.getCurrentLanguage()), parameters);
    }

    test(scriptId: number, testData: TestData, language?: string): Observable<boolean> {
        return this.http.get<boolean>('/api/scripts/test/' + testData.id + '/-1/' + (language || this.translationService.getCurrentLanguage()));
    }

    calculateRange(scriptId: number, parameters: RangeOfParameters, language?: string): Observable<Parameter[][]> {
        return this.http.post<Parameter[][]>('/api/scripts/' + scriptId + '/calculateRange/' + (language || this.translationService.getCurrentLanguage()), parameters);
    }
}
