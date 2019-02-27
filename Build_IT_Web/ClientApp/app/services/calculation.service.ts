import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Parameter } from '../models/interfaces/parameter';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CalculationService {
    constructor(private http: HttpClient) {

    }
    
    calculate(scriptId: number, parameters: Parameter[]): Observable<Parameter[]> {
        return this.http.put<Parameter[]>('/api/scripts/' + scriptId + '/calculate', parameters);
    }
}