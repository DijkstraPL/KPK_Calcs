import { Component, Input, OnInit } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { FigureService } from '../../../../services/figure.service';
import { Figure } from '../../../../models/interfaces/figure';

@Component({
    selector: 'parameter-figures',
    templateUrl: './parameter-figures.component.html',
    styleUrls: ['./parameter-figures.component.scss']
})

export class ParameterFiguresComponent implements OnInit {

    @Input() parameter: Parameter;
    figures: Figure[];
    isExpanded: boolean;
    
    constructor(private figureService: FigureService) {
    }

    ngOnInit(): void {
        this.figures = this.parameter.figures;
    }    

    expanded() {
        this.isExpanded = true;
    }

    collapsed() {
        this.isExpanded = false;
    }
}