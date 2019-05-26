var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, ElementRef, ViewChild } from '@angular/core';
import { TagService } from '../../../services/tag.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormGroup, FormControl } from '@angular/forms';
import { MatAutocomplete } from '@angular/material/autocomplete';
import { startWith, map } from 'rxjs/operators';
var TagFormComponent = /** @class */ (function () {
    function TagFormComponent(tagService) {
        this.tagService = tagService;
        this.visible = true;
        this.selectable = true;
        this.removable = true;
        this.addOnBlur = true;
        this.separatorKeysCodes = [ENTER, COMMA];
        this.tagCtrl = new FormControl();
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
        var _this = this;
        this.filteredTags = this.tagCtrl.valueChanges.pipe(startWith(null), map(function (tagName) { return tagName ? _this._filter(tagName) : _this.tags; }));
        this.getTags();
    };
    TagFormComponent.prototype.getTags = function () {
        var _this = this;
        this.tagService.getTags().subscribe(function (tags) {
            _this.tags = tags;
            _this.tagCtrl.setValue(null);
        }, function (error) { return console.error(error); });
    };
    TagFormComponent.prototype.add = function (event) {
        if (!this.matAutocomplete.isOpen) {
            var input = event.input;
            var value_1 = event.value;
            if ((value_1 || '').trim() && !this.scriptTags.controls.some(function (c) { return c.value.name == value_1.trim(); })) {
                this.scriptTags.push(new FormGroup({
                    id: new FormControl(0),
                    name: new FormControl(value_1.trim())
                }));
            }
            if (input) {
                input.value = '';
            }
            this.tagCtrl.setValue(null);
        }
    };
    TagFormComponent.prototype.remove = function (tagForm) {
        var index = this.scriptTags.controls.indexOf(tagForm);
        if (index >= 0) {
            this.scriptTags.removeAt(index);
        }
    };
    TagFormComponent.prototype.selected = function (event) {
        var tag = this.tags.find(function (t) { return t.name == event.option.viewValue; });
        if (tag == null) {
            this.tagInput.nativeElement.value = '';
            this.tagCtrl.setValue(null);
            return;
        }
        this.scriptTags.push(new FormGroup({
            id: new FormControl(tag.id),
            name: new FormControl(tag.name)
        }));
        this.tagInput.nativeElement.value = '';
        this.tagCtrl.setValue(null);
    };
    TagFormComponent.prototype._filter = function (value) {
        var filterValue = value.toLowerCase();
        return this.tags.filter(function (t) { return t.name.toLowerCase().indexOf(filterValue) === 0; });
    };
    __decorate([
        Input('scriptForm'),
        __metadata("design:type", FormGroup)
    ], TagFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        ViewChild('tagInput'),
        __metadata("design:type", ElementRef)
    ], TagFormComponent.prototype, "tagInput", void 0);
    __decorate([
        ViewChild('auto'),
        __metadata("design:type", MatAutocomplete)
    ], TagFormComponent.prototype, "matAutocomplete", void 0);
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