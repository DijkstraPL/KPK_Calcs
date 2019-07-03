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
var ScriptCardsComponent = /** @class */ (function () {
    function ScriptCardsComponent(scriptService) {
        this.scriptService = scriptService;
        this.pageSizeOptions = [5, 10, 25, 50];
        this.pageSize = 10;
    }
    ScriptCardsComponent.prototype.ngOnInit = function () {
        this.setScript();
    };
    ScriptCardsComponent.prototype.setScript = function () {
        var _this = this;
        this.scriptService.getScripts().subscribe(function (scripts) {
            _this.scripts = scripts;
            if (_this.groupFilters != undefined)
                _this.scripts = _this.scripts.filter(function (s) { return _this.groupFilters.indexOf(s.groupName) != -1; });
            if (_this.tagFilters != undefined)
                _this.scripts = _this.scripts.filter(function (s) { return _this.tagFilters.every(function (tf) { return s.tags.map(function (t) { return t.name; }).indexOf(tf) != -1; }); });
            _this.activeScripts = _this.scripts.slice(0, _this.pageSize);
            console.log("Scripts", _this.scripts);
        }, function (error) { return console.error(error); });
    };
    ScriptCardsComponent.prototype.onDeleted = function (script) {
        this.scripts = this.scripts.filter(function (s) { return s.id != script.id; });
    };
    ScriptCardsComponent.prototype.onPageChanged = function (e) {
        var firstCut = e.pageIndex * e.pageSize;
        var secondCut = firstCut + e.pageSize;
        this.activeScripts = this.scripts.slice(firstCut, secondCut);
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
        __metadata("design:paramtypes", [ScriptService])
    ], ScriptCardsComponent);
    return ScriptCardsComponent;
}());
export { ScriptCardsComponent };
//# sourceMappingURL=script-cards.component.js.map