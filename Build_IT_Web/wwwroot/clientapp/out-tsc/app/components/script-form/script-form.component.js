var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { ScriptImpl } from '../../models/scriptImpl';
import { ScriptService } from '../../services/script.service';
import { ActivatedRoute } from '@angular/router';
import { TagImpl } from '../../models/tagImpl';
import { TagService } from '../../services/tag.service';
var ScriptFormComponent = /** @class */ (function () {
    function ScriptFormComponent(scriptService, tagService, route) {
        this.scriptService = scriptService;
        this.tagService = tagService;
        this.route = route;
        this.parametersToShow = 'dataParameters';
        this.editMode = true;
        this.script = new ScriptImpl();
        this.newTag = new TagImpl();
    }
    ScriptFormComponent.prototype.ngOnInit = function () {
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (isNaN(id)) {
            this.editMode = false;
            return;
        }
        this.getScripts(id);
        this.getTags();
        this.getParameters(id);
    };
    ScriptFormComponent.prototype.getScripts = function (id) {
        var _this = this;
        this.scriptService.getScript(id).subscribe(function (script) {
            _this.script = script,
                console.log("Script", _this.script),
                _this.checked = _this.script.notes != null && _this.script.notes != '';
        }, function (error) { return console.error(error); });
    };
    ScriptFormComponent.prototype.getTags = function () {
        var _this = this;
        this.tagService.getTags().subscribe(function (tags) {
            _this.tags = tags,
                console.log("Tags", _this.tags);
        }, function (error) { return console.error(error); });
    };
    ScriptFormComponent.prototype.getParameters = function (id) {
        var _this = this;
        this.scriptService.getParameters(id).subscribe(function (parameters) {
            _this.dataParameters = parameters.filter(function (p) { return (p.context & 2) != 0; });
            _this.staticParameters = parameters.filter(function (p) { return (p.context & 8) != 0; });
            _this.calculationParameters = parameters.filter(function (p) { return (p.context & 4) != 0; }),
                console.log("Data parameters", _this.dataParameters);
            console.log("Static parameters", _this.staticParameters);
            console.log("Calculation parameters", _this.calculationParameters);
        }, function (error) { return console.error(error); });
    };
    ScriptFormComponent.prototype.addTag = function () {
        if (this.script.tags.length > 10) {
            alert("Too many tags");
            return;
        }
        this.script.tags.push(new TagImpl());
    };
    ScriptFormComponent.prototype.removeTag = function () {
        if (this.script.tags.length == 0)
            return;
        this.script.tags.pop();
    };
    ScriptFormComponent.prototype.selectedTagChanged = function (tag) {
        var tagName = this.tags.find(function (t) { return t.id == tag.id; }).name;
        this.script.tags.find(function (t) { return t.id == tag.id; }).name = tagName;
    };
    ScriptFormComponent.prototype.onSubmit = function () {
        if (!this.editMode)
            this.scriptService.create(this.script)
                .subscribe(function (s) { return console.log(s); });
        else
            this.scriptService.update(this.script)
                .subscribe(function (s) { return console.log(s); });
    };
    ScriptFormComponent.prototype.addNewTag = function () {
        var _this = this;
        this.tagService.create(this.newTag)
            .subscribe(function (t) {
            console.log(t),
                _this.getTags();
        });
    };
    ScriptFormComponent = __decorate([
        Component({
            selector: 'app-script-form',
            templateUrl: './script-form.component.html',
            styleUrls: ['./script-form.component.css']
        })
        /** script-form component*/
        ,
        __metadata("design:paramtypes", [ScriptService,
            TagService,
            ActivatedRoute])
    ], ScriptFormComponent);
    return ScriptFormComponent;
}());
export { ScriptFormComponent };
//# sourceMappingURL=script-form.component.js.map