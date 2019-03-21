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
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
var ScriptFormComponent = /** @class */ (function () {
    function ScriptFormComponent(scriptService, route, router) {
        this.scriptService = scriptService;
        this.route = route;
        this.router = router;
        this.parametersToShow = 'dataParameters';
        this.editMode = true;
        this.script = new ScriptImpl();
        this.form = new FormGroup({});
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
        this.getScript(id);
    };
    ScriptFormComponent.prototype.getScript = function (id) {
        var _this = this;
        this.scriptService.getScript(id).subscribe(function (script) {
            _this.script = script,
                console.log("Script", _this.script),
                _this.checked = _this.script.notes != null && _this.script.notes != '';
        }, function (error) { return console.error(error); });
    };
    ScriptFormComponent.prototype.onSubmit = function () {
        var _this = this;
        if (!this.editMode)
            this.scriptService.create(this.script)
                .subscribe(function (s) {
                console.log(s),
                    _this.router.navigateByUrl('/scripts/edit/' + s.id);
            });
        else
            this.scriptService.update(this.script)
                .subscribe(function (s) { return console.log(s); });
    };
    ScriptFormComponent = __decorate([
        Component({
            selector: 'app-script-form',
            templateUrl: './script-form.component.html',
            styleUrls: ['./script-form.component.css']
        }),
        __metadata("design:paramtypes", [ScriptService,
            ActivatedRoute,
            Router])
    ], ScriptFormComponent);
    return ScriptFormComponent;
}());
export { ScriptFormComponent };
//# sourceMappingURL=script-form.component.js.map