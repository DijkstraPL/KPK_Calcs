import { Component, ViewChild, ElementRef, OnInit, OnDestroy } from '@angular/core';
import { TranslationService } from '../../services/translation.service';
import { BootstrapSelectDirective } from '../../directives/bootstrap-select.directive';
import { ConfigurationService } from '../../services/configuration.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    languageChangedSubscription: any;

    @ViewChild('languageSelector', null)
    languageSelector: BootstrapSelectDirective;

    constructor(private translationService: TranslationService,
        public configurations: ConfigurationService) {

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
}