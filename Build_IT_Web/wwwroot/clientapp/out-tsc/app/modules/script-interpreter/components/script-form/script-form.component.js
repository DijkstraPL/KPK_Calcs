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
import { FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ScriptService } from '../../services/script.service';
var ScriptFormComponent = /** @class */ (function () {
    function ScriptFormComponent(scriptService, route, router) {
        this.scriptService = scriptService;
        this.route = route;
        this.router = router;
        this.scriptForm = new FormGroup({
            id: new FormControl('0'),
            name: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]),
            author: new FormControl('', Validators.maxLength(40)),
            accordingTo: new FormControl('', Validators.maxLength(50)),
            groupName: new FormControl('Other'),
            description: new FormControl('', [Validators.required, Validators.minLength(25), Validators.maxLength(500)]),
            notes: new FormControl('', Validators.maxLength(1000)),
            tags: new FormArray([])
        });
        this.parametersToShow = 'dataParameters';
        this.editMode = true;
    }
    Object.defineProperty(ScriptFormComponent.prototype, "scriptId", {
        get: function () {
            return this.scriptForm.get('id');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptFormComponent.prototype, "scriptName", {
        get: function () {
            return this.scriptForm.get('name');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ScriptFormComponent.prototype, "scriptTags", {
        get: function () {
            return this.scriptForm.get('tags');
        },
        enumerable: true,
        configurable: true
    });
    ScriptFormComponent.prototype.ngOnInit = function () {
        var id;
        var sub = this.route.params.subscribe(function (params) {
            id = +params['id'];
        });
        if (isNaN(id)) {
            this.editMode = false;
            return;
        }
        this.getScript(id);
    };
    ScriptFormComponent.prototype.getScript = function (id) {
        var _this = this;
        this.scriptService.getScript(id).subscribe(function (script) {
            console.log("Script", script);
            _this.includeNote = script.notes != null && script.notes != '';
            _this.scriptForm.patchValue(script);
        }, function (error) { throw error; });
    };
    ScriptFormComponent.prototype.onSubmit = function () {
        var _this = this;
        if (!this.editMode)
            this.scriptService.create(this.scriptForm.value)
                .subscribe(function (script) {
                console.log(script);
                _this.router.navigateByUrl('/scripts/edit/' + script.id);
            }, function (error) { throw error; });
        else
            this.scriptService.update(this.scriptForm.value)
                .subscribe(function (script) { return console.log(script); });
    };
    ScriptFormComponent = __decorate([
        Component({
            selector: 'script-form',
            templateUrl: './script-form.component.html',
            styleUrls: ['./script-form.component.scss']
        }),
        __metadata("design:paramtypes", [ScriptService,
            ActivatedRoute,
            Router])
    ], ScriptFormComponent);
    return ScriptFormComponent;
}());
export { ScriptFormComponent };
//# sourceMappingURL=script-form.component.js.map