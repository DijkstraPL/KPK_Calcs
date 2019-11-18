import { Component, OnInit } from '@angular/core';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { DeadLoadsService } from '../../../services/dead-loads.service';

@Component({
    selector: 'app-snow-loads',
    templateUrl: './snow-loads.component.html',
    styleUrls: ['./snow-loads.component.scss']
})

export class SnowLoadsComponent implements OnInit {
    loadsGroupFilter: string[] = ['Loads'];
    loadsTagFilter: string[] = ['Snow', 'Load'];

    constructor() {
    }

    ngOnInit(): void {
    }
}