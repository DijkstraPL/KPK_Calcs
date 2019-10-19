import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Parameter } from '../models/interfaces/parameter';
import { Observable } from 'rxjs';
import { TranslationService } from '../../../services/translation.service';
import { Group } from '../models/interfaces/group';

@Injectable({ providedIn: 'root' })
export class GroupService {
    constructor(private http: HttpClient,
        private translationService: TranslationService) {

    }
        
    getGroups(scriptId: number, language?: string): Observable<Group[]> {
        return this.http.get<Group[]>('/api/scripts/' + scriptId + '/groups/' + (language || this.translationService.getCurrentLanguage()));
    }

    create(scriptId: number, group: Group) {
        return this.http.post('/api/scripts/' + scriptId + '/groups', group);
    }

    update(scriptId: number, group: Group) {
        return this.http.put('/api/scripts/' + scriptId + '/groups/' + group.id, group);
    }

    delete(scriptId: number, groupId: number): Observable<Group> {
        return this.http.delete<Group>('/api/scripts/' + scriptId + '/groups/' + groupId);
    }
}
