import { Component, OnInit, Input } from '@angular/core';
import { TagImpl } from '../../../models/tagImpl';
import { Tag } from '../../../models/interfaces/tag';
import { TagService } from '../../../services/tag.service';
import { Script } from '../../../models/interfaces/script';

@Component({
    selector: 'app-tag-form',
    templateUrl: './tag-form.component.html',
    styleUrls: ['./tag-form.component.less']
})

export class TagFormComponent implements OnInit {
    @Input('script') script: Script;

    tags: Tag[];
    newTag: Tag = new TagImpl();

    constructor(private tagService: TagService) {
    }

    ngOnInit() {
        this.getTags();
    }

    private getTags() {
        this.tagService.getTags().subscribe((tags : Tag[]) => {
            this.tags = tags,
                console.log("Tags", this.tags)
        }, error => console.error(error));
    }
    
    private addTag() {
        if (this.script.tags.length > 10) {
            alert("Too many tags");
            return;
        }

        this.script.tags.push(new TagImpl());
    }

    private removeTag() {
        if (this.script.tags.length == 0)
            return;

        this.script.tags.pop();
    }

    private selectedTagChanged(tag: Tag) {
        let tagName = this.tags.find(t => t.id == tag.id).name;
        this.script.tags.find(t => t.id == tag.id).name = tagName;
    }

    private addNewTag() {
        this.tagService.create(this.newTag)
            .subscribe(t => {
                console.log(t),
                    this.getTags()
            });
    }
}