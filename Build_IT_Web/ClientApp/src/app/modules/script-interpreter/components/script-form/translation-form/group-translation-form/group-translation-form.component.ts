import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup } from '@angular/forms';
import { forkJoin, Observable } from 'rxjs';
import { AppErrorStateMatcher } from '../../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../../models/enums/language';
import { Group } from '../../../../models/interfaces/group';
import { GroupTranslation } from '../../../../models/interfaces/translations/groupTranslation';
import { GroupService } from '../../../../services/group.service';
import { GroupTranslationService } from '../../../../services/translations/group-translation.service';

@Component({
    selector: 'app-group-translation-form',
    templateUrl: './group-translation-form.component.html',
    styleUrls: ['./group-translation-form.component.scss']
})

export class GroupTranslationFormComponent implements OnInit {

    @Input('scriptForm') scriptForm: FormGroup;
    @Input('translationForm') translationForm: FormGroup;
    @Input('defaultLanguage') defaultLanguage: Language;
    @Input('translationData') translationData: { editMode: boolean, scriptId: number };

    groupsTranslationsForm = new FormArray([
        new FormGroup({
            id: new FormControl('0'),
            groupId: new FormControl('0'),
            name: new FormControl(),
            language: new FormControl('0')
        })
    ]);

    languages = Language;
    matcher = new AppErrorStateMatcher();
    groups: Group[];
    mappedGroups: {
        group: Group, translation: GroupTranslation
    }[] = [];

    get translationLanguage(): AbstractControl {
        return this.translationForm.get('language');
    }

    constructor(private groupTranslationService: GroupTranslationService,
        private groupService: GroupService) {
    }

    ngOnInit(): void {
        let groups$ = this.getGroups();
        let groupsTranslations$ = this.getGroupsTranslations();

        forkJoin([groups$, groupsTranslations$]).subscribe(results => {
            this.groups = results[0];
            results[1].forEach(gt => this.groupsTranslationsForm.push(new FormGroup({
                id: new FormControl(gt.id),
                groupId: new FormControl(gt.groupId),
                name: new FormControl(gt.name),
                language: new FormControl(gt.language)
            })));
            this.setMappedParameters();
        });
    }

    setMappedParameters() {
        this.mappedGroups = [];
        let groupsTranslation = this.groupsTranslationsForm.value as GroupTranslation[];
        this.groups.forEach(g => {
            let mappedGroup = {
                group: g, translation: groupsTranslation.find(gt => gt.groupId == g.id) ||
                    new FormGroup({
                        id: new FormControl('0'),
                        groupId: new FormControl(g.id),
                        name: new FormControl(''),
                        language: new FormControl(this.translationLanguage.value)
                    }).value as GroupTranslation
            };
            this.mappedGroups.push(mappedGroup);
        });

    }

    getGroupsTranslations(): Observable<GroupTranslation[]> {
        return this.groupTranslationService.getGroupsTranslation(this.translationData.scriptId, this.translationLanguage.value);
    }

    getGroups(): Observable<Group[]> {
        return this.groupService.getGroups(this.translationData.scriptId, this.translationLanguage.value);
    }

    groupsSubmit() {
        this.mappedGroups.forEach(mg => {
            if (mg.translation.id == 0 && mg.translation.name)
                this.createGroupTranslation(mg.translation);
            else if (mg.translation.name)
                this.updateGroupTranslation(mg.translation);
        });
    }

    updateGroupTranslation(groupTranslation: GroupTranslation) {
        this.groupTranslationService.update(groupTranslation)
            .subscribe((updatedTranslation: GroupTranslation) => {
                this.groupsTranslationsForm.clear();

                this.groupsTranslationsForm.push(new FormGroup({
                    id: new FormControl(updatedTranslation.id),
                    groupId: new FormControl(updatedTranslation.groupId),
                    name: new FormControl(updatedTranslation.name),
                    language: new FormControl(updatedTranslation.language)
                }));
            });
    }

    createGroupTranslation(groupTranslation: GroupTranslation) {
        this.groupTranslationService.create(groupTranslation)
            .subscribe((newTranslation: GroupTranslation) => {
                this.groupsTranslationsForm.clear();
                this.groupsTranslationsForm.push(new FormGroup({
                    id: new FormControl(newTranslation.id),
                    groupId: new FormControl(newTranslation.groupId),
                    name: new FormControl(newTranslation.name),
                    language: new FormControl(newTranslation.language)
                }));
            });
    }
}
