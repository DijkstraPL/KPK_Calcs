import { Component, OnInit } from '@angular/core';
import { MaterialForCalculations } from '../../../models/dead-loads/material-for-calculations';
import { DeadLoadsService } from '../../../services/dead-loads.service';

@Component({
    selector: 'app-dead-loads',
    templateUrl: './dead-loads.component.html',
    styleUrls: ['./dead-loads.component.less']
})

export class DeadLoadsComponent implements OnInit {
    newMaterial: MaterialForCalculations;
    
    constructor() {
    }

    onMaterialAdded(material: MaterialForCalculations): void {
        this.newMaterial = material;
    }

    ngOnInit(): void {
    }
}