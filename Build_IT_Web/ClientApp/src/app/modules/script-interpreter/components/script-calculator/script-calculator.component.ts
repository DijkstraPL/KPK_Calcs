import { Component, OnInit } from '@angular/core';
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
import { TranslationService } from '../../../../services/translation.service';
import { retry } from 'rxjs/operators';
import { Group } from '../../models/interfaces/group';

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
    notGroupedResultParameters: Parameter[];
    groupsResultParameters: ParametersGroup[];

    groups: ParametersGroup[];
    notGroupedParameters: Parameter[];

    valueChanged: boolean;
    parameterOptions = ParameterOptions;

    isCalculating: boolean;
    errorMessages: string[];
    
    constructor(
        private route: ActivatedRoute,
        private scriptService: ScriptService,
        private parameterService: ParameterService,
        private calculationService: CalculationService,
        private translationService: TranslationService) {
    }

    ngOnInit(): void {
        let id;
        let sub = this.route.params.subscribe(params => {
            id = +params['id'];
        });
        if (id != undefined)
            this.getScript(id);
        sub.unsubscribe();

        this.translationService.languageChanged$.subscribe(language => {
            if (id != undefined) {
                this.getScript(id, language);
                this.resultParameters = [];
                this.valueChanged = true;
            }
        });
    }

    private getScript(id: number, language?: string) {
        this.scriptService.getScript(id).subscribe(script => {
            this.script = script;
            console.log("Script", this.script);
            this.setParameters();
        }, error => console.error(error));
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
        parameter.valueOptions = parameter.valueOptions.sort((a, b) => a.number - b.number);

        let value = sessionStorage.getItem("Script" + this.script.id + parameter.name);
        if (value != null)
            parameter.value = value;
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

        sessionStorage.setItem("Script" + this.script.id + parameter.name, parameter.value);

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
        let groups: Group[] = [];
        this.parameters.forEach(vp => {
            if (vp.group != null && groups.every(g => g.id != vp.group.id))
                groups.push(vp.group)
        });

        this.groups = groups.map(gn => new ParametersGroup(gn));
    }

    private populateGroups() {
        this.groups.forEach(g => g.clear());
        this.notGroupedParameters = [];

        this.visibleParameters.forEach(vp => {
            if (vp.group == undefined || vp.group.name == "" || vp.group.name == undefined)
                this.notGroupedParameters.push(vp);
            else {
                let group = this.groups.find(g => g.group.name === vp.group.name)
                group.addParameter(vp);
            }
        });
    }

    isValid(): boolean {
        let visibleParameters = this.parameters
            .filter(p => (p.context & ParameterOptions.editable) != 0 &&
                (p.context & ParameterOptions.optional) == 0 &&
                this.validateVisibility(p));

        let validationResult = visibleParameters
            .every(p => p.value != undefined && p.value != "" && this.validateData(p));

        if (!validationResult)
            this.setErrorMessages(visibleParameters);
        else
            this.errorMessages = [];

        return validationResult;
    }

    clean() {
        this.parameters.forEach(p => {
            sessionStorage.removeItem("Script" + this.script.id + p.name);
            p.value = p.equation;
        });

        this.valueChanged = true;
    }

    calculate() {
        this.isCalculating = true;
        this.calculationService.calculate(this.script.id, this.parameters.filter(p => this.validateVisibility(p)))
            .subscribe(params => {
                this.resultParameters = params.filter(p => (p.context & ParameterOptions.visible) != 0);
                this.resultParameters.forEach(p => p.equation = this.setEquation(p));
                this.filterResults(this.resultParameters);
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

    filterResults(resultParameters: Parameter[]) {
        this.notGroupedResultParameters = [];
        this.groupsResultParameters = [];

        resultParameters.forEach(rp => {
            if (rp.group == null)
                this.notGroupedResultParameters.push(rp);
            else if (rp.group != null &&
                this.groupsResultParameters
                    .every(g => g.group.id != rp.group.id)) {
                let group = new ParametersGroup(rp.group);
                group.addParameter(rp);
                this.groupsResultParameters.push(group);
            }
            else {
                let group = this.groupsResultParameters
                    .find(grp => grp.group.id == rp.group.id);
                group.addParameter(rp);
            }
        });
    }

    private setEquation(parameter: Parameter): string {
        let firstPartOfEquation = parameter.equation.replace(/\[/g, '').replace(/\]/g, '');
        let secondPartOfEquation = parameter.equation;

        this.parameters.concat(this.staticDataParameters).concat(this.resultParameters).forEach(p => {
            secondPartOfEquation = secondPartOfEquation.replace(`[${p.name}]`, ` ${p.value}${p.unit} `);
        });

        return firstPartOfEquation + ' = ' + secondPartOfEquation;
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

    private validateData(parameter: Parameter): boolean {
        if (!parameter.dataValidator)
            return true;

        let dataValidatorEquation = parameter.dataValidator;

        this.parameters.forEach(p => {
            let value = p.valueType == ValueType.number ? p.value : `'${p.value}'`;
            dataValidatorEquation = dataValidatorEquation.split(`[${p.name}]`).join(value);
        });

        try {
            let result = eval(dataValidatorEquation) as boolean;
            if (result != null)
                return result;
            else
                return true;
        } catch (e) {
            return true;
        }
    }

    private setErrorMessages(visibleParameters: Parameter[]) {
        this.errorMessages = [];
        let wrongParameters = visibleParameters.filter(p => p.value && p.dataValidator && !this.validateData(p));

        wrongParameters.forEach(wp => {
            let pureValidationEquation = wp.dataValidator
                .replace('[', '')
                .replace(']', '')
                .replace('&&', ' AND ')
                .replace('||', ' OR ')
                .replace(/\s{2,}/g, ' ')
                .replace(/\r?\n|\r/g, ' ');
            this.errorMessages.push(pureValidationEquation);
        });
    }
}
