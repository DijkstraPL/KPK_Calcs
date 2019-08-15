var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, EventEmitter, Output } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { AuthService } from '../../../../services/auth.service';
var ScriptCardComponent = /** @class */ (function () {
    function ScriptCardComponent(scriptService, auth) {
        this.scriptService = scriptService;
        this.auth = auth;
        this.deleted = new EventEmitter();
    }
    ScriptCardComponent.prototype.delete = function (script) {
        var _this = this;
        if (confirm("Are you sure that you want to remove \"" + script.name + "\"?")) {
            this.scriptService.delete(script.id).subscribe(function () {
                _this.deleted.emit(script.id);
            });
        }
    };
    __decorate([
        Input('script'),
        __metadata("design:type", Object)
    ], ScriptCardComponent.prototype, "script", void 0);
    __decorate([
        Output('deleted'),
        __metadata("design:type", Object)
    ], ScriptCardComponent.prototype, "deleted", void 0);
    ScriptCardComponent = __decorate([
        Component({
            selector: 'app-script-card',
            templateUrl: './script-card.component.html',
            styleUrls: ['./script-card.component.scss']
        }),
        __metadata("design:paramtypes", [ScriptService,
            AuthService])
    ], ScriptCardComponent);
    return ScriptCardComponent;
}());
export { ScriptCardComponent };
//# sourceMappingURL=script-card.component.js.map