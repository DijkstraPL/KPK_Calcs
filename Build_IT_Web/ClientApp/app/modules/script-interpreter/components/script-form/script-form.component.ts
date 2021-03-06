﻿import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators, AbstractControl, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Script } from '../../models/interfaces/script';
import { ScriptImpl } from '../../models/scriptImpl';
import { ScriptService } from '../../services/script.service';
import { AppErrorStateMatcher } from '../../../../common/errors/app-error-state-matcher';
import { TagService } from '../../services/tag.service';
import { Tag } from '../../models/interfaces/tag';
import { Observable, forkJoin } from 'rxjs';
import { ParametersFormComponent } from './parameters-form/parameters-form.component';
import { CreateScriptCommand } from '../../models/api/scripts/create-script-command';

@Component({
    selector: 'script-form',
    templateUrl: './script-form.component.html',
    styleUrls: ['./script-form.component.scss']
})

export class ScriptFormComponent implements OnInit {

    scriptForm = new FormGroup({
        id: new FormControl('0'),
        name: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]),
        author: new FormControl('', Validators.maxLength(40)),
        accordingTo: new FormControl('', Validators.maxLength(50)),
        groupName: new FormControl('Other'),
        description: new FormControl('', [Validators.required, Validators.minLength(25), Validators.maxLength(500)]),
        notes: new FormControl('', Validators.maxLength(1000)),
        defaultLanguage: new FormControl('0', Validators.required),
        tags: new FormArray([])
    });

    parametersToShow: string = 'dataParameters';
    editMode: boolean = true;
    includeNote: boolean;

    @ViewChild(ParametersFormComponent, { static: false }) private parametersForm: ParametersFormComponent;

    get scriptId(): AbstractControl {
        return this.scriptForm.get('id');
    }
    get scriptName(): AbstractControl {
        return this.scriptForm.get('name');
    }
    get scriptTags(): FormArray {
        return this.scriptForm.get('tags') as FormArray;
    }
    get scriptDefaultLanguage(): AbstractControl {
        return this.scriptForm.get('defaultLanguage');
    }

    constructor(
        private scriptService: ScriptService,
        private tagService: TagService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {
        let id;
        let sub = this.route.params.subscribe(params => {
            id = +params['id'];
        });

        if (isNaN(id)) {
            this.editMode = false;
            return;
        }
        this.getScript(id);
    }

    private getScript(id: number) {
        this.scriptService.getScript(id, "en").subscribe(script => {
            console.log("Script", script);
            this.includeNote = script.notes != null && script.notes != '';
            this.scriptForm.patchValue(script);
            script.tags.forEach(t => this.scriptTags.push(
                new FormGroup({
                    id: new FormControl(t.id),
                    name: new FormControl(t.name)
                })));
        }, error => { throw error });
    }

    async onSubmit() {
       await this._setTags();

        if (!this.editMode) {
            this.scriptService.create(this.scriptForm.value)
                .subscribe((createdScript: any) => {
                    this.router.navigateByUrl('/scripts/edit/' + createdScript.id);
                }, error => { throw error });
        }
        else
            this.scriptService.update(this.scriptForm.value)
                .subscribe(() => { });

       this.parametersForm.saveParameters();
    }

    private async _setTags() {
        for (let tag of this.scriptTags.value)
            if (tag.id == 0) {
                let newTag = await this._setTag(tag);
                tag.id = newTag.id;
            }
    }

    private async _setTag(tag: Tag) {
        var newTag = await this.tagService.create(tag).toPromise();
        return newTag;
    }
}