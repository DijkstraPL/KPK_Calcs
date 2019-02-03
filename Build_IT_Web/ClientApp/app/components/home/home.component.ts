import { Component, OnInit } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/script';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
    scripts: Script[];

    constructor(private scriptService: ScriptService) {

    }

    ngOnInit(): void {
        this.setScript();
    }

    private setScript(): void {
        this.scriptService.getScripts().subscribe(scripts => {
            this.scripts = scripts;
            console.log("Scripts", this.scripts);
        }, error => console.error(error));
    }

    private delete(script: Script): void {
        if (confirm(`Are you sure that you want to remove \"${script.name}\"?`)) {
            this.scriptService.deleteScript(script.id).subscribe(s =>
                console.log("Scripts", s));
            this.scripts = this.scripts.filter(s => s.id != script.id);
        }
    }
}