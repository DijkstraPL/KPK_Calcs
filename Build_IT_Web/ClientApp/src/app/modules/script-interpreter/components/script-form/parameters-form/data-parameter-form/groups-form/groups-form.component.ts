import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../../../common/errors/app-error-state-matcher';
import { GroupService } from '../../../../../services/group.service';
import { Group } from '../../../../../models/interfaces/group';
import { Subscription, forkJoin, Observable } from 'rxjs';
import { Parameter } from '../../../../../models/interfaces/parameter';

@Component({
    selector: 'app-groups-form',
    templateUrl: './groups-form.component.html',
    styleUrls: ['./groups-form.component.scss']
})

export class GroupsFormComponent implements OnInit {

    @Input('scriptId') scriptId: number;
    @Input('parameters') parameters: Parameter[];

    groups: Group[];
    groupForms = new FormArray([]);

    matcher = new AppErrorStateMatcher();
    
    constructor(private groupService: GroupService) {
    }

    ngOnInit(): void {
        this.getGroups();
    }

    remove(group: FormGroup) {
        if (this.parameters.some(p => p.group != null && p.group.id == group.value.id)) {
            alert("This group is in use. Abort!");
            return;
        }

        this.groupForms.removeAt(this.groupForms.controls.findIndex(g => g.value.id == group.value.id));
        if (group.value.id != 0) {
            this.groupService.delete(this.scriptId, group.value.id).subscribe(g => {
            }, error => console.error(error));
        }
    }

    add() {
        this.groupForms.push(new FormGroup({
            id: new FormControl(0),
            name: new FormControl("", [Validators.required, Validators.maxLength(50)]),
            visibilityValidator: new FormControl("", Validators.maxLength(1000)),
            scriptId: new FormControl(this.scriptId)
        }));
    }

    save() {
        let subscriptions: Observable<any>[] = [];

        this.groupForms.controls.forEach(g => {
            if (g.value.id == 0)
                subscriptions.push( this.groupService.create(this.scriptId, g.value));
            else
                subscriptions.push(this.groupService.update(this.scriptId, g.value));
        });

        forkJoin(subscriptions)
            .subscribe(() => {
                this.getGroups();
            }, error => console.error(error));
    }

    private getGroups() {
        this.groupForms.clear();
        this.groupService.getGroups(this.scriptId, "en")
            .subscribe(groups => {
                this.groups = groups.sort(this.sortByName());
                this.groups.forEach(g => {
                    this.groupForms.push(new FormGroup({
                        id: new FormControl(g.id),
                        name: new FormControl(g.name, [Validators.required, Validators.maxLength(50)]),
                        visibilityValidator: new FormControl(g.visibilityValidator, Validators.maxLength(1000)),
                        scriptId: new FormControl(this.scriptId)
                    }));
                });
            }, error => console.error(error));
    }

    private sortByName(): (a: Group, b: Group) => number {
        return (a, b) => {
            if (a.name == b.name)
                return 0;
            return a.name > b.name ? 1 : -1;
        };
    }
}
