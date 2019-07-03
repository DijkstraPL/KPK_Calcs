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
import { FormGroup } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';
import { Language } from '../../../models/enums/language';
var ScriptDataFormComponent = /** @class */ (function () {
    function ScriptDataFormComponent() {
        this.languages = Language;
        this.matcher = new AppErrorStateMatcher();
    }
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptAuthor", {
        get: function () {
            return this.scriptForm.get('author');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptDocument", {
        get: function () {
            return this.scriptForm.get('accordingTo');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptGroup", {
        get: function () {
            return this.scriptForm.get('groupName');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptDescription", {
        get: function () {
            return this.scriptForm.get('description');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptNotes", {
        get: function () {
            return this.scriptForm.get('notes');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptDataFormComponent.prototype, "scriptDefaultLanguage", {
        get: function () {
            return this.scriptForm.get('defaultLanguage');
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        Input('scriptForm'),
        __metadata("design:type", FormGroup)
    ], ScriptDataFormComponent.prototype, "scriptForm", void 0);
    __decorate([
        Input('includeNote'),
        __metadata("design:type", Boolean)
    ], ScriptDataFormComponent.prototype, "includeNote", void 0);
    ScriptDataFormComponent = __decorate([
        Component({
            selector: 'script-data-form',
            templateUrl: './script-data-form.component.html',
            styleUrls: ['./script-data-form.component.scss']
        })
    ], ScriptDataFormComponent);
    return ScriptDataFormComponent;
}());
export { ScriptDataFormComponent };
//# sourceMappingURL=script-data-form.component.js.map