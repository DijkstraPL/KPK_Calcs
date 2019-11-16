import { Component, Input, OnInit } from '@angular/core';
import { ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { Parameter } from '../../../../models/interfaces/parameter';
import { Script } from '../../../../models/interfaces/script';
import { RangeOfParameters } from '../../../../models/rangeOfParameters';
import { CalculationService } from '../../../../services/calculation.service';
import { ValueType } from '../../../../models/enums/valueType';
import { isNullOrUndefined } from 'util';
import { ParameterOptions } from '../../../../models/enums/parameterOptions';

@Component({
    selector: 'chart-result',
    templateUrl: './chart-result.component.html',
    styleUrls: ['./chart-result.component.scss']
})

export class ChartResultComponent implements OnInit {

    _parameters: Parameter[];
    @Input('script') script: Script;

    @Input('parameters')
    set parameters(val: Parameter[]) {
        this._parameters = val;
        if (this._parameters)
            this.availableParameters = this._parameters.filter(p => this.validateVisibility(p) &&
                p.valueType == ValueType.number);
    }
    get parameters() {
        return this._parameters;
    }

    availableParameters: Parameter[];
    valueType = ValueType;

    minValue: number;
    maxValue: number;
    tick: number;
    selectedParameter: Parameter;

    isCalculating: boolean;

    public lineChartData: ChartDataSets[] = [];
    public lineChartLabels: Label[] = [];
    public lineChartOptions = {
        responsive: true,
    };
    public lineChartColors: Color[] = [
        { backgroundColor: 'rgba(255,0,0,0.3)' },
        { backgroundColor: 'rgba(0,255,0,0.3)' },
        { backgroundColor: 'rgba(0,0,255,0.3)' },
        { backgroundColor: 'rgba(255,255,0,0.3)' },
        { backgroundColor: 'rgba(255,0,255,0.3)' },
        { backgroundColor: 'rgba(0,255,255,0.3)' },
        { backgroundColor: 'rgba(255,255,255,0.3)' },
    ];
    public lineChartLegend = true;
    public lineChartType = 'line';
    public lineChartPlugins = [];

    constructor(private calculationService: CalculationService) { }

    ngOnInit() {
    }

    calculateRange() {
        this.isCalculating = true;
        let range = new RangeOfParameters();
        range.maxValue = this.maxValue;
        range.minValue = this.minValue;
        range.tick = this.tick;
        range.parameterId = this.selectedParameter.id;
        range.parameters = this.parameters.filter(p => this.validateVisibility(p));

        this.lineChartLabels = [];
        let currentValue = this.minValue;
        while (currentValue <= this.maxValue) {
            this.lineChartLabels.push(currentValue.toString());
            currentValue += this.tick;
        }

        this.calculationService.calculateRange(this.script.id, range)
            .subscribe(params => {
                console.log(params);
                let allParameters: Parameter[] = [];
                params.forEach(p => p.forEach(inner => {
                    if (allParameters.every(ap => ap.name != inner.name))
                        allParameters.push(inner);
                }));
                allParameters = allParameters.sort((p1, p2) => p1.number - p2.number);

                this.lineChartData = [];
                for (let parameter of allParameters) {
                    if (parameter.valueType == ValueType.number && (parameter.context & ParameterOptions.visible) != 0)
                        this.lineChartData.push({
                            data: params.map(p => {
                                let currentParameter = p.find(p => p.name == parameter.name);
                                if (isNullOrUndefined(currentParameter))
                                    return NaN;
                                return +currentParameter.value.replace(',', '.');
                            }),
                            label: parameter.name,
                            lineTension: 0,
                            hidden: (parameter.context & ParameterOptions.important) == 0,
                            borderColor: 'black',
                        });

                }
            },
                error => {
                    console.error(error);
                    this.isCalculating = false;
                },
                () => {
                    this.isCalculating = false;
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
