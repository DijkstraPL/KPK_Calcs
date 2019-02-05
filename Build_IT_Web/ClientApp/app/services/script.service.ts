import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Script } from '../models/script';
import { Parameter } from '../models/parameter';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ScriptService {
    constructor(private http: HttpClient) {

    }

    getScripts(): Observable<Script[]> {
        return this.http.get<Script[]>('/api/scripts');
    }

    getScript(id: number): Observable<Script> {
        return this.http.get<Script>('/api/scripts/'+id);
    }

    deleteScript(id: number): Observable<Script> {
        return this.http.delete<Script>('/api/scripts/' + id);
    }

    getEditableParameters(scriptId: number): Observable<Parameter[]> {
        return this.http.get<Parameter[]>('/api/scripts/' + scriptId + '/editable_parameters');
    }

    getParameters(scriptId: number): Observable<Parameter[]> {
        return this.http.get<Parameter[]>('/api/scripts/' + scriptId + '/parameters');
    }

    create(script: Script) {
        return this.http.post('/api/scripts', script);
    }

    update(script: Script) {
        return this.http.put('/api/scripts/' + script.id, script);
    }

    calculate(scriptId: number, parameters: Parameter[]): Observable<Parameter[]> {
        return this.http.put<Parameter[]>('/api/scripts/' + scriptId + '/calculate', parameters);
    }
}