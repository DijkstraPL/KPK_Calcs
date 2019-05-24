import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tag } from '../models/interfaces/tag';
import { Observable } from 'rxjs';

@Injectable()
export class TagService {
    constructor(private http: HttpClient) {

    }
    
    getTags(): Observable<Tag[]> {
        return this.http.get<Tag[]>('/api/tags');
    }

    getTagsForScript(scriptId: number): Observable<Tag[]> {
        return this.http.get<Tag[]>('/api/tags/' + scriptId);
    }

    create(newTag: Tag): any {
        return this.http.post('/api/tags', newTag);
    }
}