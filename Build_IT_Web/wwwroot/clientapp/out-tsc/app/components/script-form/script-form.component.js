var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var ScriptFormComponent = /** @class */ (function () {
    function ScriptFormComponent() {
        this.checked = false;
        this.counter = 0;
        this.parametersToShow = 'dataParameters';
    }
    ScriptFormComponent.prototype.addTag = function () {
        if (this.counter > 11) {
            alert("Too many tags");
            return;
        }
        var input = document.createElement("input");
        input.type = "text";
        input.classList.add("form-control");
        input.classList.add("scriptTag");
        var div = document.createElement("div");
        div.classList.add("form-group");
        div.classList.add("col-md-2");
        div.appendChild(input);
        var tags = document.getElementById("tags");
        tags.appendChild(div);
        this.counter++;
    };
    ScriptFormComponent.prototype.removeTag = function () {
        if (this.counter == 0)
            return;
        this.counter--;
        var tags = document.getElementById("tags");
        var div = tags.lastElementChild;
        div.remove();
    };
    ScriptFormComponent.prototype.onSubmit = function () {
        alert(this.script.name);
    };
    ScriptFormComponent = __decorate([
        Component({
            selector: 'app-script-form',
            templateUrl: './script-form.component.html',
            styleUrls: ['./script-form.component.css']
        })
        /** script-form component*/
    ], ScriptFormComponent);
    return ScriptFormComponent;
}());
export { ScriptFormComponent };
//# sourceMappingURL=script-form.component.js.map