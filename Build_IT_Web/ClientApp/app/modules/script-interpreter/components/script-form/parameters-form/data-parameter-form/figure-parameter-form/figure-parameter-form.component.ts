import { Component, ViewChild, ElementRef, Input, OnInit } from '@angular/core';
import { FigureService } from '../../../../../services/figure.service';
import { Parameter } from '../../../../../models/interfaces/parameter';
import { Figure } from '../../../../../models/interfaces/figure';
import { FormGroup, AbstractControl } from '@angular/forms';

@Component({
    selector: 'app-figure-parameter-form',
    templateUrl: './figure-parameter-form.component.html',
    styleUrls: ['./figure-parameter-form.component.scss']
})

export class FigureParameterFormComponent implements OnInit {
    @Input('parameterForm') parameterForm: FormGroup;

    figures: Figure[];

    @ViewChild('fileInput', { static: false }) fileInput: ElementRef;

    get parameterId(): AbstractControl {
        return this.parameterForm.get('id');
    }
    get parameterFigures(): AbstractControl {
        return this.parameterForm.get('figures');
    }

    constructor(private figureService: FigureService) {

    }
    ngOnInit(): void {
        this.figures = this.parameterFigures.value;
    }

    uploadFigure() {
        let nativeELement: HTMLInputElement = this.fileInput.nativeElement;

        this.figureService.upload(this.parameterId.value, nativeELement.files[0])
            .subscribe((figure: Figure) => {
                this.figures.push(figure)
            });
    }
}