import { Component, Input } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/interfaces/script';
import { PageEvent } from '@angular/material/paginator';

@Component({
    selector: 'app-script-cards',
    templateUrl: './script-cards.component.html',
    styleUrls: ['./script-cards.component.scss']
})

export class ScriptCardsComponent {
    scripts: Script[];
    @Input('groupFilters') groupFilters?: string[];
    @Input('tagFilters') tagFilters?: string[];

    activeScripts: Script[];

    pageSizeOptions: number[] = [5, 10, 25, 50];
    pageEvent: PageEvent;
    pageSize = 10;

    constructor(private scriptService: ScriptService) {
    }

    ngOnInit(): void {
        this.setScript();
    }

    private setScript(): void {
        this.scriptService.getScripts().subscribe((scripts: Script[]) => {

            this.scripts = scripts;
            this.setFilteredScripts();
        }, error => console.error(error));
    }

    private setFilteredScripts() {
        if (this.groupFilters != undefined)
            this.scripts = this.scripts.filter(s => this.groupFilters.indexOf(s.groupName) != -1);
        if (this.tagFilters != undefined)
            this.scripts = this.scripts.filter(s => this.tagFilters.every(tf => s.tags.map(t => t.name).indexOf(tf) != -1));
        this.activeScripts = this.scripts.slice(0, this.pageSize);
        console.log("Scripts", this.scripts);
    }

    onDeleted(scriptId: number) {
        this.scripts = this.scripts.filter(s => s.id != scriptId);
        this.setFilteredScripts();
    }

    onPageChanged(e) {
        let firstCut = e.pageIndex * e.pageSize;
        let secondCut = firstCut + e.pageSize;
        this.activeScripts = this.scripts.slice(firstCut, secondCut);
    }
}