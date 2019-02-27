import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Script } from '../models/interfaces/script';
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

    delete(id: number): Observable<Script> {
        return this.http.delete<Script>('/api/scripts/' + id);
    }
    
    create(script: Script) {
        return this.http.post('/api/scripts', script);
    }

    update(script: Script) {
        return this.http.put('/api/scripts/' + script.id, script);
    }
}