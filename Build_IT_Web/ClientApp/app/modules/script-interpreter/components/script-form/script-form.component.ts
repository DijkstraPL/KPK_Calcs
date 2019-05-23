import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, AbstractControl, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Script } from '../../models/interfaces/script';
import { ScriptImpl } from '../../models/scriptImpl';
import { ScriptService } from '../../services/script.service';
import { AppErrorStateMatcher } from '../../../../common/errors/app-error-state-matcher';

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
        tags: new FormGroup({})
    });
    
    parametersToShow: string = 'dataParameters';
    editMode: boolean = true;
    includeNote: boolean;
    
    get scriptName(): AbstractControl {
        return this.scriptForm.get('name');
    }

    constructor(
        private scriptService: ScriptService,
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
        this.scriptService.getScript(id).subscribe(script => {
            console.log("Script", script);
            this.includeNote = script.notes != null && script.notes != '';
            this.scriptForm.patchValue(script);
        }, error => { throw error });
    }

    onSubmit() {
        if (!this.editMode)
            this.scriptService.create(this.scriptForm.value)
                .subscribe((script: Script) => {
                    console.log(script);
                    this.router.navigateByUrl('/scripts/edit/' + script.id);
                }, error => { throw error });
        else
            this.scriptService.update(this.scriptForm.value)
                .subscribe((script: Script) => console.log(script));
    }
}