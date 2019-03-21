import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Script } from '../../models/interfaces/script';
import { ScriptImpl } from '../../models/scriptImpl';
import { ScriptService } from '../../services/script.service';

@Component({
    selector: 'app-script-form',
    templateUrl: './script-form.component.html',
    styleUrls: ['./script-form.component.css']
})

export class ScriptFormComponent implements OnInit {
    checked: boolean;
    parametersToShow: string = 'dataParameters';
    editMode: boolean = true;

    script: Script = new ScriptImpl();

    scriptForm = new FormGroup({
        name: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required)
    });

    get scriptName() {
        return this.scriptForm.get('name');
    }
    get scriptDescription() {
        return this.scriptForm.get('description');
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
            this.script = script,
                console.log("Script", this.script),
                this.checked = this.script.notes != null && this.script.notes != '';
        }, error => console.error(error));
    }


    onSubmit() {
        if (!this.editMode)
            this.scriptService.create(this.script)
                .subscribe((s: Script) => {
                    console.log(s),
                        this.router.navigateByUrl('/scripts/edit/' + s.id);
                });
        else
            this.scriptService.update(this.script)
                .subscribe(s => console.log(s));
    }

}