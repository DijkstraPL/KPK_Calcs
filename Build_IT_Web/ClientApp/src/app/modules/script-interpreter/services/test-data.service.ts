import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TranslationService } from '../../../services/translation.service';
import { TestData } from '../models/interfaces/testData';

@Injectable({ providedIn: 'root' })
export class TestDataService {

    constructor(private http: HttpClient,
        private translationService: TranslationService) {

    }

    getTestDatas(scriptId: number, language?: string): Observable<TestData[]> {
        return this.http.get<TestData[]>('/api/testData/' + scriptId + '/' + (language || this.translationService.getCurrentLanguage()));
    }

    create(scriptId: number, testData: TestData) {
        return this.http.post('/api/testData/' + scriptId , testData);
    }

    delete(testDataId: number) {
        return this.http.delete('/api/testData/' + testDataId);
    }


    //update(scriptId: number, parameter: Parameter) {
    //    return this.http.put('/api/scripts/' + scriptId + '/parameters/' + parameter.id, parameter);
    //}

}
