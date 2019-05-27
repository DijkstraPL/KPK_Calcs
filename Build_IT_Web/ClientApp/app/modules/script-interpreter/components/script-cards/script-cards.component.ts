import { Component, Input } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/interfaces/script';

@Component({
    selector: 'app-script-cards',
    templateUrl: './script-cards.component.html',
    styleUrls: ['./script-cards.component.scss']
})

export class ScriptCardsComponent {
    scripts: Script[];
    @Input('groupFilters') groupFilters?: string[];
    @Input('tagFilters') tagFilters?: string[];

    constructor(private scriptService: ScriptService) {
    }

    ngOnInit(): void {
        this.setScript();
    }

    private setScript(): void {
        this.scriptService.getScripts().subscribe((scripts: Script[]) => {

            this.scripts = scripts;
            if (this.groupFilters != undefined)
                this.scripts = this.scripts.filter(s => this.groupFilters.indexOf(s.groupName) != -1);
            if (this.tagFilters != undefined)
                this.scripts = this.scripts.filter(s => this.tagFilters.every(tf => s.tags.map(t => t.name).indexOf(tf) != -1));
            console.log("Scripts", this.scripts);
        }, error => console.error(error));
    }

    onDeleted(script: Script) {
        this.scripts = this.scripts.filter(s => s.id != script.id);
    }
}