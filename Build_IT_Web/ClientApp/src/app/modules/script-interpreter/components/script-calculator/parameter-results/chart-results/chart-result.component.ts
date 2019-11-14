import { Component, Input, OnInit } from '@angular/core';
import { ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { Parameter } from '../../../../models/interfaces/parameter';
import { Script } from '../../../../models/interfaces/script';
import { RangeOfParameters } from '../../../../models/rangeOfParameters';
import { CalculationService } from '../../../../services/calculation.service';
import { ValueType } from '../../../../models/enums/valueType';

@Component({
    selector: 'chart-result',
    templateUrl: './chart-result.component.html',
    styleUrls: ['./chart-result.component.scss']
})

export class ChartResultComponent implements OnInit {

    @Input('parameters') parameters: Parameter[];
    @Input('script') script: Script;

    public lineChartData: ChartDataSets[] = [
        { data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A' },
    ];
    public lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
    public lineChartOptions = {
        responsive: true,
    };
    public lineChartColors: Color[] = [
        {
            borderColor: 'black',
            backgroundColor: 'rgba(255,0,0,0.3)',
        },
    ];
    public lineChartLegend = true;
    public lineChartType = 'line';
    public lineChartPlugins = [];

    constructor(private calculationService: CalculationService) { }

    ngOnInit() {
    }


    calculateRange() {
        //this.isCalculating = true;
        let range = new RangeOfParameters();
        range.maxValue = 500;
        range.minValue = 100;
        range.tick = 10;
        range.parameterId = this.parameters[0].id;
        range.parameters = this.parameters.filter(p => this.validateVisibility(p));

        this.calculationService.calculateRange(this.script.id, range)
            .subscribe(params => {
                console.log(params);

                this.lineChartData.push({ data: params.map(p => +p.find(p => p.id == range.parameterId).value), label: this.parameters[0].name })
            },
                error => {
                    console.error(error);
                    //this.isCalculating = false;
                },
                () => {
                    //this.isCalculating = false;
                    //this.valueChanged = false;
                });
    }

    private validateVisibility(parameter: Parameter): boolean {
        let group = parameter.group;

        let visibilityValidatorEquation = "";
        if (group != null && group.visibilityValidator)
            visibilityValidatorEquation = group.visibilityValidator;
        if (!visibilityValidatorEquation)
            visibilityValidatorEquation = parameter.visibilityValidator;
        else if (parameter.visibilityValidator)
            visibilityValidatorEquation = `(${visibilityValidatorEquation})&&(${parameter.visibilityValidator})`;

        if (!visibilityValidatorEquation)
            return true;

        this.parameters.forEach(p => {
            let value = p.valueType == ValueType.number ? p.value : `'${p.value}'`;
            visibilityValidatorEquation = visibilityValidatorEquation.split(`[${p.name}]`).join(value);
        });

        try {
            let result = eval(visibilityValidatorEquation) as boolean;
            if (result != null && !result && parameter.value != parameter.equation)
                parameter.value = parameter.equation;
            if (result != null)
                return result;
            else
                return true;
        } catch (e) {
            return true;
        }
    }

}
