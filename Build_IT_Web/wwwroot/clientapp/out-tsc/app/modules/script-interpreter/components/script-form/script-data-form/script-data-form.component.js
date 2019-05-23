var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AppErrorStateMatcher } from '../../../../../common/errors/app-error-state-matcher';
var ScriptDataFormComponent = /** @class */ (function () {
    function ScriptDataFormComponent() {
        this.scriptForm = new FormGroup({
            id: new FormControl('0'),
            name: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]),
            author: new FormControl('', Validators.maxLength(40)),
            accordingTo: new FormControl('', Validators.maxLength(50)),
            groupName: new FormControl('Other'),
            description: new FormControl('', [Validators.required, Validators.minLength(25), Validators.maxLength(500)]),
            notes: new FormControl('', Validators.maxLength(1000))
        });
        this.matcher = new AppErrorStateMatcher();
        this.editMode = true;
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
    ScriptDataFormComponent = __decorate([
        Component({
            selector: 'script-data-form',
            templateUrl: './script-data.component.html',
            styleUrls: ['./script-data.component.scss']
        })
    ], ScriptDataFormComponent);
    return ScriptDataFormComponent;
}());
export { ScriptDataFormComponent };
//# sourceMappingURL=script-data-form.component.js.map