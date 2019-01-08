import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Script } from '../models/script';
import { Parameter } from '../models/parameter';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ScriptService {

    scripts: Script[] = [];

    constructor(private http: HttpClient) {

    }

    getScripts(): Observable<Script[]> {
        return this.http.get<Script[]>('/api/scripts');
    }

    getParameters(scriptId: number): Observable<Parameter[]> {
        return this.http.get<Parameter[]>('/api/scripts/' + scriptId + '/parameters');
    }

    calculate(scriptName: string, parameters: string): Observable<Parameter[]> {
        return this.http.get<Parameter[]>('/api/scripts/calculate/' + scriptName + '/' + parameters);
    }

}