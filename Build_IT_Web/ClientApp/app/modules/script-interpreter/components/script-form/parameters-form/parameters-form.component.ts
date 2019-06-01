﻿import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParameterFilter } from '../../../models/enums/parameter-filter';
import { Parameter } from '../../../models/interfaces/parameter';
import { ParameterImpl } from '../../../models/parameterImpl';
import { ParameterService } from '../../../services/parameter.service';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
    selector: 'app-parameters-form',
    templateUrl: './parameters-form.component.html',
    styleUrls: ['./parameters-form.component.scss']
})

export class ParametersFormComponent implements OnInit {
    parameters: Parameter[];
    filteredParameters: Parameter[];
    newParameter: Parameter = new ParameterImpl();

    scriptId: number;
    editMode: boolean = false;
    newlyAddedParameter: boolean = false;
    parametersToShow: string = "all";

    constructor(private parameterService: ParameterService,
        private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.scriptId = +params['id'];
        });

        if (isNaN(this.scriptId))
            return;

        this.getParameters(this.scriptId);
    }

    drop(event: CdkDragDrop<Parameter[]>): void {
        moveItemInArray(this.filteredParameters, event.previousIndex, event.currentIndex);

        this.setNumbers(event);
    }

    private setNumbers(event: CdkDragDrop<Parameter[]>): void {
        let sortedParameters = this.sortParameters(this.filteredParameters, 'number');

        let addition = this.getAddition();

        sortedParameters[event.previousIndex].number = event.currentIndex + addition;

        if (event.currentIndex < event.previousIndex) {
            let i = event.previousIndex - 1;
            for (i; i >= event.currentIndex; i--)
                sortedParameters[i].number = sortedParameters[i].number + 1;
        }
        else if (event.currentIndex > event.previousIndex) {
            let i = event.currentIndex;
            for (i; i > event.previousIndex; i--)
                sortedParameters[i].number = sortedParameters[i].number - 1;
        }
    }

    private getAddition() {
        let addition = 0;
        if (this.parametersToShow == 'data')
            addition = 0;
        if (this.parametersToShow == 'static' || this.parametersToShow == 'calculation') {
            let parametersFilterCriteria = ParameterFilter['data'];
            addition += this.parameters.filter(p => (p.context & parametersFilterCriteria) != 0).length;
        }
        if (this.parametersToShow == 'calculation') {
            let parametersFilterCriteria = ParameterFilter['static'];
            addition += this.parameters.filter(p => (p.context & parametersFilterCriteria) != 0).length;
        }
        return addition;
    }

    getParameters(id: number) {
        this.parameterService.getParameters(id).subscribe(parameters => {
            this.parameters = parameters;
            this.onParametersToShowChange();
            console.log("Parameters", this.parameters);
        }, error => console.error(error));
    }

    onParametersToShowChange() {
        let parametersFilterCriteria = ParameterFilter[this.parametersToShow];

        switch (parametersFilterCriteria) {
            case ParameterFilter.all:
                this.filteredParameters = this.parameters;
                break;
            default:
                this.filteredParameters = this.parameters.filter(p => (p.context & parametersFilterCriteria) != 0);
                break;
        }
    }

    editParameter(parameter: Parameter) {
        this.editMode = true;
        this.newlyAddedParameter = false;
        this.newParameter = parameter;
    }

    remove(parameterId: number) {
        if (confirm("Are you sure?"))
            this.parameterService.delete(this.scriptId, parameterId)
                .subscribe((p: Parameter) => {
                    this.parameters = this.parameters.filter(p => p.id != parameterId)
                    this.onParametersToShowChange();
                    this.changeNumbering(p.number);
                    console.log("Parameters", p)
                }, error => console.error(error));
    }

    private changeNumbering(number: number) {
        this.parameters
            .filter(p => p.number > number)
            .forEach(p => p.number -= 1);
    }

    onCreated(parameter: Parameter) {
        if (this.parameters.length > 0)
            parameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number })) + 1;
        else
            parameter.number = 0;
        this.parameterService.create(this.scriptId, parameter)
            .subscribe((p: Parameter) => {
                console.log(p);
                this.parameters.push(p);
            });
    }

    changeEditMode() {
        if (this.editMode) {
            this.editMode = false;
            this.newlyAddedParameter = false;
            this.newParameter = null;
        }
    }

    sortParameters(parameters: Parameter[], prop: string) {
        if (parameters)
            return parameters.sort(
                (a, b) => a[prop] > b[prop] ? 1 :
                    a[prop] === b[prop] ? 0 :
                        -1);
    }

    addNewParameter(): void {
        this.editMode = true;
        this.newlyAddedParameter = true;
        this.newParameter = new ParameterImpl();
        this.newParameter.number = Math.max.apply(Math, this.parameters.map(function (p) { return p.number; })) + 1;
    }

    saveParameters() {
        this.parameters.forEach(p => {
            this.parameterService.update(this.scriptId, p)
                .subscribe((p: Parameter) => {
                    console.log(p);
                },
                    error => console.error(error))
        });
    }
}