import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Figure } from '../../../../../models/interfaces/figure';
import { FigureService } from '../../../../../services/figure.service';

@Component({
    selector: 'app-existing-figures-dialog',
    templateUrl: './existing-figures-dialog.component.html',
    styleUrls: ['./existing-figures-dialog.component.scss']
})

export class ExistingFiguresDialogComponent implements OnInit {
    figures: Figure[];

    constructor(
        public dialogRef: MatDialogRef<ExistingFiguresDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public figure: Figure,
        private figureService: FigureService) { }

    ngOnInit(): void {
        //this.figureService.getAllFigures()
        //    .subscribe(f => this.figures = f);
    }

    onNoClick(): void {
        this.dialogRef.close();
    }
}