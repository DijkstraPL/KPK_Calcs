import { Component, Input } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/interfaces/script';
import { PageEvent } from '@angular/material/paginator';
import { TranslationService } from '../../../../services/translation.service';
import { LocalStoreManager } from '../../../../services/local-store-manager.service';
import { DBkeys } from '../../../../services/db-keys';
import { SearchService } from '../../../../services/search.service';
import { stringify } from '@angular/compiler/src/util';

@Component({
    selector: 'app-script-cards',
    templateUrl: './script-cards.component.html',
    styleUrls: ['./script-cards.component.scss']
})

export class ScriptCardsComponent {
    scripts: Script[];
    filteredScripts: Script[];
    @Input('groupFilters') groupFilters?: string[];
    @Input('tagFilters') tagFilters?: string[];

    activeScripts: Script[];

    pageSizeOptions: number[] = [5, 10, 25, 50];
    pageEvent: PageEvent;
    pageSize = 10;
    pageIndex = 0;

    filterValue: string;

    constructor(private scriptService: ScriptService,
        private translationService: TranslationService,
        private localStorage: LocalStoreManager,
        private searchService: SearchService) {
    }

    ngOnInit(): void {
        this.setScripts();
        this.translationService.languageChanged$.subscribe(language => {
            this.setScripts(language);
        });

        this.searchService.searched$.subscribe(value => {
            this.filterValue = value;
            this.setFilteredScripts();
        });
    }

    private setScripts(lang?: string): void {
        this.scriptService.getScripts(lang).subscribe((scripts: Script[]) => {

            this.scripts = scripts;
            this.setFilteredScripts();
            this.setPage();
        }, error => console.error(error));
    }

    private setFilteredScripts() {
        this.filteredScripts = this.scripts;
        if (this.groupFilters != undefined)
            this.filteredScripts = this.filteredScripts.filter(s => this.groupFilters.indexOf(s.groupName) != -1);
        if (this.tagFilters != undefined)
            this.filteredScripts = this.filteredScripts.filter(s => this.tagFilters.every(tf => s.tags.map(t => t.name).indexOf(tf) != -1));
        if (this.filterValue)
            this.filteredScripts = this.filteredScripts.filter(s =>
                s.name && s.name.toLowerCase().indexOf(this.filterValue.toLowerCase()) >= 0 ||
                s.author && s.author.toLowerCase().indexOf(this.filterValue.toLowerCase()) >= 0 ||
                s.accordingTo && s.accordingTo.toLowerCase().indexOf(this.filterValue.toLowerCase()) >= 0 ||
                s.groupName && s.groupName.toLowerCase().indexOf(this.filterValue.toLowerCase()) >= 0 ||
                s.tags && s.tags.some(t => t.name && t.name.toLowerCase().indexOf(this.filterValue.toLowerCase()) >= 0) 
            );
        console.log(this.filteredScripts);
        this.activeScripts = this.filteredScripts.slice(0, this.pageSize);
    }

    onDeleted(scriptId: number) {
        this.scripts = this.scripts.filter(s => s.id != scriptId);
        this.setFilteredScripts();
    }

    onPageChanged(e) {
        setTimeout(() => {
            this.localStorage.savePermanentData(e.pageSize, DBkeys.PAGESIZE);
            this.localStorage.savePermanentData(e.pageIndex, DBkeys.PAGEINDEX);
        });

        this.setPage(e);
    }

    private setPage(e?: PageEvent) {
        let pageSize = this.pageSize;
        let pageIndex = 0;
        if (e != undefined) {
            pageSize = e.pageSize;
            pageIndex = e.pageIndex;
        }
        else if (this.localStorage.exists(DBkeys.PAGESIZE) && this.localStorage.exists(DBkeys.PAGEINDEX)) {
            pageSize = this.localStorage.getData(DBkeys.PAGESIZE);
            pageIndex = this.localStorage.getData(DBkeys.PAGEINDEX);
        }

        while (pageIndex * pageSize > this.filteredScripts.length)
            pageIndex -= 1;

        let firstCut = pageIndex * pageSize;
        let secondCut = firstCut + pageSize;

        this.pageSize = pageSize;
        this.pageIndex = pageIndex;

        this.activeScripts = this.filteredScripts.slice(firstCut, secondCut);
    }
}