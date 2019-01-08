import { Component, OnInit } from '@angular/core';
import { ScriptService } from '../../services/script.service';
import { Script } from '../../models/script';
import { Tag } from "../../models/tag";

@Component({
    selector: 'app-script-calculator',
    templateUrl: './script-calculator.component.html',
    styleUrls: ['./script-calculator.component.css']
})

export class ScriptCalculatorComponent implements OnInit {

    scripts: Script[] = [];
    selectedScript: Script;

    constructor(private scriptService: ScriptService) {

    }

    ngOnInit(): void {
        this.scriptService.getScripts().subscribe(scripts => {
            this.scripts = scripts;
            console.log("Scripts", this.scripts);
        }, error => console.error(error));
    }
}