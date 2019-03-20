import { Component, Input, Pipe, OnInit } from '@angular/core';
import { ScriptImpl } from '../../models/scriptImpl';
import { ScriptService } from '../../services/script.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Script } from '../../models/interfaces/script';
import { TagImpl } from '../../models/tagImpl';
import { TagService } from '../../services/tag.service';
import { Tag } from '../../models/interfaces/tag';
import { Parameter } from '../../models/interfaces/parameter';

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