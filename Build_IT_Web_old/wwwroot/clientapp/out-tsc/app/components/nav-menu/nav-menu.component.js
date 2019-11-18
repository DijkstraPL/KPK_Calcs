var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, ViewChild } from '@angular/core';
import { TranslationService } from '../../services/translation.service';
import { ElementSelectDirective } from '../../directives/element-select.directive';
import { ConfigurationService } from '../../services/configuration.service';
import { FormGroup, FormControl } from '@angular/forms';
import { SearchService } from '../../services/search.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { MatBottomSheet } from '@angular/material/bottom-sheet';
import { LoginComponent } from '../login/login.component';
var NavMenuComponent = /** @class */ (function () {
    function NavMenuComponent(translationService, auth, configurations, searchService, router, bottomSheet) {
        this.translationService = translationService;
        this.auth = auth;
        this.configurations = configurations;
        this.searchService = searchService;
        this.router = router;
        this.bottomSheet = bottomSheet;
        this.searchForm = new FormGroup({
            search: new FormControl('')
        });
    }
    Object.defineProperty(NavMenuComponent.prototype, "searchValue", {
        get: function () {
            return this.searchForm.get('search');
        },
        enumerable: true,
        configurable: true
    });
    NavMenuComponent.prototype.logout = function () {
        if (this.auth.logout())
            this.router.navigate([""]);
        return false;
    };
    NavMenuComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.languageChangedSubscription = this.translationService.languageChanged$.subscribe(function (data) {
            setTimeout(function () {
                _this.languageSelector.refresh();
            });
        });
    };
    NavMenuComponent.prototype.ngOnDestroy = function () {
        this.languageChangedSubscription.unsubscribe();
    };
    NavMenuComponent.prototype.onSearch = function () {
        this.searchService.search(this.searchValue.value);
    };
    NavMenuComponent.prototype.openLoginSheet = function () {
        this.bottomSheet.open(LoginComponent);
    };
    __decorate([
        ViewChild('languageSelector', null),
        __metadata("design:type", ElementSelectDirective)
    ], NavMenuComponent.prototype, "languageSelector", void 0);
    NavMenuComponent = __decorate([
        Component({
            selector: 'app-nav-menu',
            templateUrl: './nav-menu.component.html',
            styleUrls: ['./nav-menu.component.css']
        }),
        __metadata("design:paramtypes", [TranslationService,
            AuthService,
            ConfigurationService,
            SearchService,
            Router,
            MatBottomSheet])
    ], NavMenuComponent);
    return NavMenuComponent;
}());
export { NavMenuComponent };
//# sourceMappingURL=nav-menu.component.js.map