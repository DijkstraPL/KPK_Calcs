import { Component, Input, OnInit, Inject } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { FigureService } from '../../../../services/figure.service';
import { Figure } from '../../../../models/interfaces/figure';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'parameter-figures',
    templateUrl: './parameter-figures.component.html',
    styleUrls: ['./parameter-figures.component.scss']
})

export class ParameterFiguresComponent {
        
    constructor(
        public dialogRef: MatDialogRef<ParameterFiguresComponent>,
        @Inject(MAT_DIALOG_DATA) public parameter: Parameter) {
    }

    onCloseClick(): void {
        this.dialogRef.close();
    }
}