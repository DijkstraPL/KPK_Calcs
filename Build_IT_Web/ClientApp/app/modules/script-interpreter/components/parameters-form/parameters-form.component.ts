import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParameterFilter } from '../../models/enums/parameter-filter';
import { Parameter } from '../../models/interfaces/parameter';
import { ParameterImpl } from '../../models/parameterImpl';
import { ParameterService } from '../../services/parameter.service';

@Component({
    selector: 'app-parameters-form',
    templateUrl: './parameters-form.component.html',
    styleUrls: ['./parameters-form.component.css']
})
/** parameters-form component*/
export class ParametersFormComponent implements OnInit {
    parameters: Parameter[];
    filteredParameters: Parameter[];
    newParameter: Parameter = new ParameterImpl();

    scriptId: number;
    editMode: boolean = false;
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
        this.newParameter = parameter;
    }

    remove(parameterId: number) {
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe((p: Parameter) => {
                this.parameters = this.parameters.filter(p => p.id != parameterId)
                this.onParametersToShowChange();
                console.log("Parameters", p)
            }, error => console.error(error));
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
        if (!this.editMode)
            this.newParameter = new ParameterImpl();
    }

    sortParameters(parameters: Parameter[], prop: string) {
        if (parameters)
            return parameters.sort(
                (a, b) => a[prop] > b[prop] ? 1 :
                    a[prop] === b[prop] ? 0 :
                        -1);
    }

    moveUp(parameter: Parameter) {
        let sortedParameters = this.sortParameters(this.parameters, 'number');
        let currentIndex = sortedParameters.indexOf(parameter);
        if (currentIndex === sortedParameters.length - 1)
            return;

        let tempNumber = parameter.number;
        parameter.number = sortedParameters[currentIndex + 1].number;
        sortedParameters[currentIndex + 1].number = tempNumber;

        this.saveParameters();
    }

    moveDown(parameter: Parameter) {
        let sortedParameters = this.sortParameters(this.parameters, 'number');
        let currentIndex = sortedParameters.indexOf(parameter);
        if (currentIndex === 0)
            return;

        let tempNumber = parameter.number;
        parameter.number = sortedParameters[currentIndex - 1].number;
        sortedParameters[currentIndex - 1].number = tempNumber;

        this.saveParameters();
    }

    private saveParameters() {
        this.parameters.forEach(p => {
            this.parameterService.update(this.scriptId, p)
                .subscribe((p: Parameter) => {
                    console.log(p);
                },
                    error => console.error(error))
        });
    }
}