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
import { TagImpl } from '../../../models/tagImpl';
import { TagService } from '../../../services/tag.service';
var TagFormComponent = /** @class */ (function () {
    function TagFormComponent(tagService) {
        this.tagService = tagService;
        this.newTag = new TagImpl();
    }
    TagFormComponent.prototype.ngOnInit = function () {
        this.getTags();
    };
    TagFormComponent.prototype.getTags = function () {
        var _this = this;
        this.tagService.getTags().subscribe(function (tags) {
            _this.tags = tags,
                console.log("Tags", _this.tags);
        }, function (error) { return console.error(error); });
    };
    TagFormComponent.prototype.addTag = function () {
        if (this.script.tags.length > 10) {
            alert("Too many tags");
            return;
        }
        this.script.tags.push(new TagImpl());
    };
    TagFormComponent.prototype.removeTag = function () {
        if (this.script.tags.length == 0)
            return;
        this.script.tags.pop();
    };
    TagFormComponent.prototype.selectedTagChanged = function (tag) {
        var tagName = this.tags.find(function (t) { return t.id == tag.id; }).name;
        this.script.tags.find(function (t) { return t.id == tag.id; }).name = tagName;
    };
    TagFormComponent.prototype.addNewTag = function () {
        var _this = this;
        this.tagService.create(this.newTag)
            .subscribe(function (t) {
            console.log(t),
                _this.getTags();
        });
    };
    __decorate([
        Input('script'),
        __metadata("design:type", Object)
    ], TagFormComponent.prototype, "script", void 0);
    TagFormComponent = __decorate([
        Component({
            selector: 'tag-form',
            templateUrl: './tag-form.component.html',
            styleUrls: ['./tag-form.component.scss']
        }),
        __metadata("design:paramtypes", [TagService])
    ], TagFormComponent);
    return TagFormComponent;
}());
export { TagFormComponent };
//# sourceMappingURL=tag-form.component.js.map