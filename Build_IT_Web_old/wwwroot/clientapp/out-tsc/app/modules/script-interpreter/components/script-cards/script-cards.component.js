var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { TranslationService } from '../../../../services/translation.service';
import { LocalStoreManager } from '../../../../services/local-store-manager.service';
import { DBkeys } from '../../../../services/db-keys';
import { SearchService } from '../../../../services/search.service';
var ScriptCardsComponent = /** @class */ (function () {
    function ScriptCardsComponent(scriptService, translationService, localStorage, searchService) {
        this.scriptService = scriptService;
        this.translationService = translationService;
        this.localStorage = localStorage;
        this.searchService = searchService;
        this.pageSizeOptions = [5, 10, 25, 50];
        this.pageSize = 10;
        this.pageIndex = 0;
    }
    ScriptCardsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.setScripts();
        this.translationService.languageChanged$.subscribe(function (language) {
            _this.setScripts(language);
        });
        this.searchService.searched$.subscribe(function (value) {
            _this.filterValue = value;
            _this.setFilteredScripts();
        });
    };
    ScriptCardsComponent.prototype.setScripts = function (lang) {
        var _this = this;
        this.scriptService.getScripts(lang).subscribe(function (scripts) {
            _this.scripts = scripts;
            _this.setFilteredScripts();
            _this.setPage();
        }, function (error) { return console.error(error); });
    };
    ScriptCardsComponent.prototype.setFilteredScripts = function () {
        var _this = this;
        this.filteredScripts = this.scripts;
        if (this.groupFilters != undefined)
            this.filteredScripts = this.filteredScripts.filter(function (s) { return _this.groupFilters.indexOf(s.groupName) != -1; });
        if (this.tagFilters != undefined)
            this.filteredScripts = this.filteredScripts.filter(function (s) { return _this.tagFilters.every(function (tf) { return s.tags.map(function (t) { return t.name; }).indexOf(tf) != -1; }); });
        if (this.filterValue)
            this.filteredScripts = this.filteredScripts.filter(function (s) {
                return s.name && s.name.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.author && s.author.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.accordingTo && s.accordingTo.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.groupName && s.groupName.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0 ||
                    s.tags && s.tags.some(function (t) { return t.name && t.name.toLowerCase().indexOf(_this.filterValue.toLowerCase()) >= 0; });
            });
        console.log(this.filteredScripts);
        this.activeScripts = this.filteredScripts.slice(0, this.pageSize);
    };
    ScriptCardsComponent.prototype.onDeleted = function (scriptId) {
        this.scripts = this.scripts.filter(function (s) { return s.id != scriptId; });
        this.setFilteredScripts();
    };
    ScriptCardsComponent.prototype.onPageChanged = function (e) {
        var _this = this;
        setTimeout(function () {
            _this.localStorage.savePermanentData(e.pageSize, DBkeys.PAGESIZE);
            _this.localStorage.savePermanentData(e.pageIndex, DBkeys.PAGEINDEX);
        });
        this.setPage(e);
    };
    ScriptCardsComponent.prototype.setPage = function (e) {
        var pageSize = this.pageSize;
        var pageIndex = 0;
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
        var firstCut = pageIndex * pageSize;
        var secondCut = firstCut + pageSize;
        this.pageSize = pageSize;
        this.pageIndex = pageIndex;
        this.activeScripts = this.filteredScripts.slice(firstCut, secondCut);
    };
    __decorate([
        Input('groupFilters'),
        __metadata("design:type", Array)
    ], ScriptCardsComponent.prototype, "groupFilters", void 0);
    __decorate([
        Input('tagFilters'),
        __metadata("design:type", Array)
    ], ScriptCardsComponent.prototype, "tagFilters", void 0);
    ScriptCardsComponent = __decorate([
        Component({
            selector: 'app-script-cards',
            templateUrl: './script-cards.component.html',
            styleUrls: ['./script-cards.component.scss']
        }),
        __metadata("design:paramtypes", [ScriptService,
            TranslationService,
            LocalStoreManager,
            SearchService])
    ], ScriptCardsComponent);
    return ScriptCardsComponent;
}());
export { ScriptCardsComponent };
//# sourceMappingURL=script-cards.component.js.map