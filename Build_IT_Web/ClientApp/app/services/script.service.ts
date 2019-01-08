import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Script } from '../models/script';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ScriptService {

    scripts: Script[] = [];

    constructor(private http: HttpClient) {

    }

    getScripts(): Observable<Script[]> {
        return this.http.get<Script[]>('/api/scripts');
    }
}