import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Script } from '../../models/interfaces/script'
import { ScriptService } from '../../services/script.service';

@Component({
    selector: 'app-script-card',
    templateUrl: './script-card.component.html',
    styleUrls: ['./script-card.component.less']
})

export class ScriptCardComponent {
    @Input('script') script: Script;
    @Output('deleted') deleted = new EventEmitter<Script>();

    constructor(private scriptService: ScriptService) {
    }
       
    private delete(script: Script): void {
        if (confirm(`Are you sure that you want to remove \"${script.name}\"?`)) {
            this.scriptService.delete(script.id).subscribe((s: Script) => {
                console.log("Scripts", s);
                this.deleted.emit(script);
            });
        }
    }
}