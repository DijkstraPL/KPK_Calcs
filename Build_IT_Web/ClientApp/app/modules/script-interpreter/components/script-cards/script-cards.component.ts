import { Component } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/interfaces/script';

@Component({
    selector: 'app-script-cards',
    templateUrl: './script-cards.component.html',
    styleUrls: ['./script-cards.component.scss']
})

export class ScriptCardsComponent {
    scripts: Script[];

    constructor(private scriptService: ScriptService) {
    }

    ngOnInit(): void {
        this.setScript();
    }

    private setScript(): void {
        this.scriptService.getScripts().subscribe((scripts: Script[]) => {
            this.scripts = scripts;
            console.log("Scripts", this.scripts);
        }, error => console.error(error));
    }

    onDeleted(script: Script) {
        this.scripts = this.scripts.filter(s => s.id != script.id);
    }
}