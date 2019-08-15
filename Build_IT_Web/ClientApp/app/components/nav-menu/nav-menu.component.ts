import { Component, ViewChild, ElementRef, OnInit, OnDestroy } from '@angular/core';
import { TranslationService } from '../../services/translation.service';
import { ElementSelectDirective } from '../../directives/element-select.directive';
import { ConfigurationService } from '../../services/configuration.service';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';
import { SearchService } from '../../services/search.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

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
        public auth: AuthService,
        public configurations: ConfigurationService,
        private searchService: SearchService,
        private router: Router) {

    }

    logout(): boolean {
        if (this.auth.logout()) 
            this.router.navigate([""]);
        return false;
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