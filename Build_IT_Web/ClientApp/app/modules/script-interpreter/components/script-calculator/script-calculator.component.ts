﻿import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ParameterOptions } from '../../models/enums/parameterOptions';
import { ValueType } from '../../models/enums/valueType';
import { Parameter } from '../../models/interfaces/parameter';
import { Script } from '../../models/interfaces/script';
import { ParametersGroup } from '../../models/parametersGroup';
import { CalculationService } from '../../services/calculation.service';
import { ParameterService } from '../../services/parameter.service';
import { ScriptService } from '../../services/script.service';

@Component({
    selector: 'script-calculator',
    templateUrl: './script-calculator.component.html',
    styleUrls: ['./script-calculator.component.scss']
})

export class ScriptCalculatorComponent implements OnInit {
    myControl = new FormControl();

    script: Script;
    parameters: Parameter[];
    visibleParameters: Parameter[];
    staticDataParameters: Parameter[];
    resultParameters: Parameter[];

    groups: ParametersGroup[];
    notGroupedParameters: Parameter[];

    valueChanged: boolean;
    parameterOptions = ParameterOptions;

    isCalculating: boolean;

    constructor(
        private route: ActivatedRoute,
        private scriptService: ScriptService,
        private parameterService: ParameterService,
        private calculationService: CalculationService) {
    }

    ngOnInit(): void {
        let id;
        let sub = this.route.params.subscribe(params => {
            id = +params['id'];
        });
        if (id != undefined) {
            this.scriptService.getScript(id).subscribe(script => {
                this.script = script;
                console.log("Script", this.script);
                this.setParameters();
            }, error => console.error(error));
        }
        sub.unsubscribe();
    }

    private setParameters(): void {
        this.parameterService.getParameters(this.script.id).subscribe(parameters => {
            this.parameters = parameters.filter(p => (p.context & ParameterOptions.editable) != 0),
                this.staticDataParameters = parameters.filter(p =>
                    (p.context & ParameterOptions.staticData) != 0 && 
                    (p.context & ParameterOptions.visible) != 0),
                this.parameters.forEach(p => this.prepareParameter(p)),
                this.filterParameters(),
                console.log("Parameters", this.parameters);
        }, error => console.error(error));
    }

    private prepareParameter(parameter: Parameter): void {
        parameter.equation = parameter.value;
    }

    sortParameters(parameters: Parameter[], prop: string) {
        if (parameters)
            return parameters.sort(
                (a, b) => a[prop] > b[prop] ? 1 :
                    a[prop] === b[prop] ? 0 :
                        -1);
    }

    onValueChanged(parameter: Parameter) {
        this.valueChanged = true;

        this.filterParameters();
    }


    filterParameters() {
        this.visibleParameters = this.parameters.filter(p =>
            (p.context & ParameterOptions.visible) != 0 &&
            this.validateVisibility(p));

        if (this.groups == undefined)
            this.createGroups();
        this.populateGroups();
    }

    private createGroups() {
        let groupNames = this.visibleParameters.map(vp => vp.groupName)
            .filter((value, index, self) => self.indexOf(value) === index &&
                value != "" && value != undefined);

        this.groups = groupNames.map(gn => new ParametersGroup(gn));
    }

    private populateGroups() {
        this.groups.forEach(g => g.clear());
        this.notGroupedParameters = [];

        this.visibleParameters.forEach(vp => {
            if (vp.groupName == "" || vp.groupName == undefined)
                this.notGroupedParameters.push(vp);
            else {
                let group = this.groups.find(g => g.name === vp.groupName)
                group.addParameter(vp);
            }
        });
    }

    calculate() {
        this.isCalculating = true;
        this.calculationService.calculate(this.script.id, this.parameters)
            .subscribe(params => {
                this.resultParameters = params.filter(p => (p.context & ParameterOptions.visible) != 0);
                console.log("Results", this.resultParameters);
            },
                error => {
                    console.error(error);
                    this.isCalculating = false;
                },
                () => {
                    this.isCalculating = false;
                    this.valueChanged = false;
                });
    }

    private validateVisibility(parameter: Parameter): boolean {
        if (!parameter.visibilityValidator)
            return true;

        let visibilityValidatorEquation = parameter.visibilityValidator.slice(
            parameter.visibilityValidator.indexOf('(') + 1,
            parameter.visibilityValidator.lastIndexOf(')'));

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