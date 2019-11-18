import { Component, Input } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Parameter } from '../../../../models/interfaces/parameter';
import { ParameterFiguresComponent } from '../figures/parameter-figures.component';

@Component({
    selector: 'figures-button',
    templateUrl: './figures-button.component.html',
    styleUrls: ['./figures-button.component.scss']
})

export class FiguresButtonComponent {

    @Input() parameter: Parameter;

    constructor(public dialog: MatDialog) {
    }
    
    openFigures() {

        const dialogConfig = new MatDialogConfig();

        dialogConfig.disableClose = false;
        dialogConfig.autoFocus = true;
        dialogConfig.width = 'auto';
        dialogConfig.data = this.parameter;

        const dialogRef = this.dialog.open(ParameterFiguresComponent, dialogConfig);

        dialogRef.afterClosed().subscribe(result => {
        });
    }
}