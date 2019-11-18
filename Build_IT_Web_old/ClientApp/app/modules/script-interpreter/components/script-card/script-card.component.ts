import { Component, Input, EventEmitter, Output } from '@angular/core';
import { Script } from '../../models/interfaces/script'
import { ScriptService } from '../../services/script.service';
import { AuthService } from '../../../../services/auth.service';

@Component({
    selector: 'app-script-card',
    templateUrl: './script-card.component.html',
    styleUrls: ['./script-card.component.scss']
})

export class ScriptCardComponent {
    @Input('script') script: Script;
    @Output('deleted') deleted = new EventEmitter<number>();

    constructor(private scriptService: ScriptService,
        public auth: AuthService) {
    }
       
    delete(script: Script): void {
        if (confirm(`Are you sure that you want to remove \"${script.name}\"?`)) {
            this.scriptService.delete(script.id).subscribe(() => {
                this.deleted.emit(script.id);
            });
        }
    }
}