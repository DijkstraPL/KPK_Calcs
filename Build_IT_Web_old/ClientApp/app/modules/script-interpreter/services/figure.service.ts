import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Figure } from '../models/interfaces/figure';

@Injectable({ providedIn: 'root' })
export class FigureService {
    constructor(private http: HttpClient) {

    }
    
    getFigures(parameterId: number): Observable<any> {
        return this.http.get(`/api/parameters/${parameterId}/figures`);
    }

    upload(parameterId: number, photo) {
        var formData = new FormData();
        formData.append('file', photo);
        return this.http.post(`/api/parameters/${parameterId}/figures`, formData);
    }

    detach(parameterId: number, figureId: number): Observable<Figure> {
        return this.http.delete<Figure>('/api/parameters/' + parameterId + '/figures/' + figureId);
    }
}