import { Component, ViewChild, ElementRef, OnInit, OnDestroy } from '@angular/core';
import { TranslationService } from '../../services/translation.service';
import { ElementSelectDirective } from '../../directives/element-select.directive';
import { ConfigurationService } from '../../services/configuration.service';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';
import { SearchService } from '../../services/search.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    languageChangedSubscription: any;

    @ViewChild('languageSelector', null)
    languageSelector: ElementSelectDirective;

    searchForm = new FormGroup({
        search: new FormControl('')
    });

    get searchValue(): AbstractControl{
        return this.searchForm.get('search');
    }

    constructor(private translationService: TranslationService,
        public configurations: ConfigurationService,
        private searchService: SearchService) {

    }

    ngOnInit() {
        this.languageChangedSubscription = this.translationService.languageChanged$.subscribe(data => {
     
            setTimeout(() => {
                this.languageSelector.refresh();
            });
        });
    }

    ngOnDestroy() {
        this.languageChangedSubscription.unsubscribe();
    }

    onSearch() {
        this.searchService.search(this.searchValue.value);
    }
}