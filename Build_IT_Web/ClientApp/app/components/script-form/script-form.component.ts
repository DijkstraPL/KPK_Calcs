import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-script-form',
    templateUrl: './script-form.component.html',
    styleUrls: ['./script-form.component.css']
})
/** script-form component*/
export class ScriptFormComponent {
    checked: boolean = false;   
    counter: number = 0;
    parametersToShow: string = 'dataParameters';

    addTag() {
        if (this.counter > 11) {
            alert("Too many tags");
            return;
        }

        let input = document.createElement("input");
        input.type = "text";
        input.classList.add("form-control");
        input.classList.add("scriptTag");

        let div = document.createElement("div");
        div.classList.add("form-group");
        div.classList.add("col-md-2");
        div.appendChild(input);

        let tags = document.getElementById("tags");
        tags.appendChild(div);
        this.counter++;
    }

    removeTag() {
        if (this.counter == 0)
            return;
        this.counter--;

        let tags = document.getElementById("tags");
        let div = tags.lastElementChild;
        div.remove();
    }
}