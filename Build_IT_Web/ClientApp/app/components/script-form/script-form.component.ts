import { Component, Input, Pipe, OnInit } from '@angular/core';
import { ScriptImpl } from '../../models/scriptImpl';
import { ScriptService } from '../../services/script.service';
import { ActivatedRoute } from '@angular/router';
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
    tags: Tag[];
    newTag: Tag = new TagImpl();

    constructor(
        private scriptService: ScriptService,
        private tagService: TagService,
        private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.getTags();

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

    private getTags() {
        this.tagService.getTags().subscribe(tags => {
            this.tags = tags,
                console.log("Tags", this.tags)
        }, error => console.error(error));
    }

    addTag() {
        if (this.script.tags.length > 10) {
            alert("Too many tags");
            return;
        }

        this.script.tags.push(new TagImpl());
    }

    removeTag() {
        if (this.script.tags.length == 0)
            return;

        this.script.tags.pop();
    }

    selectedTagChanged(tag: Tag) {
        let tagName = this.tags.find(t => t.id == tag.id).name;
        this.script.tags.find(t => t.id == tag.id).name = tagName;
    }

    onSubmit() {
        if (!this.editMode)
            this.scriptService.create(this.script)
                .subscribe(s => console.log(s));
        else
            this.scriptService.update(this.script)
                .subscribe(s => console.log(s));
    }

    addNewTag() {
        this.tagService.create(this.newTag)
            .subscribe(t => {
                console.log(t),
                    this.getTags()
            });
    }
}