import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FigureService {
    constructor(private http: HttpClient) {

    }
    
    getFigures(parameterId: number): Observable<any> {
        return this.http.get(`/api/parameters/${parameterId}/photos`);
    }

    upload(parameterId: number, photo) {
        var formData = new FormData();
        formData.append('file', photo);
        return this.http.post(`/api/parameters/${parameterId}/photos`, formData);
    }
}