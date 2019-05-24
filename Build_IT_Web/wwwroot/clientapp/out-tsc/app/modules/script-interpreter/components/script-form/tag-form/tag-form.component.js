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
import { TagService } from '../../../services/tag.service';
import { FormGroup, FormControl } from '@angular/forms';
var TagFormComponent = /** @class */ (function () {
    function TagFormComponent(tagService) {
        this.tagService = tagService;
    }
    Object.defineProperty(TagFormComponent.prototype, "scriptId", {
        get: function () {
            return this.scriptForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(TagFormComponent.prototype, "scriptTags", {
        get: function () {
            return this.scriptForm.get('tags');
        },
        enumerable: true,
        configurable: true
    });
    TagFormComponent.prototype.ngOnInit = function () {
        this.getTags();
    };
    TagFormComponent.prototype.getTags = function () {
        var _this = this;
        this.tagService.getTagsForScript(this.scriptId.value).subscribe(function (tags) {
            tags.forEach(function (t) { return _this.scriptTags.push(new FormControl(t.name)); });
        }, function (error) { return console.error(error); });
    };
    __decorate([
        Input('scriptForm'),
        __metadata("design:type", FormGroup)
    ], TagFormComponent.prototype, "scriptForm", void 0);
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