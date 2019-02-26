import { Component, OnInit, Output } from '@angular/core';
import { Parameter } from '../../models/parameter';
import { ScriptService } from '../../services/script.service';
import { ActivatedRoute } from '@angular/router';
import { ParameterImpl } from '../../models/parameterImpl';
import { ParameterService } from '../../services/parameter.service';
import { ParameterOptions } from '../../models/parameterOptions';
import { ValueOptionImpl } from '../../models/valueOptionImpl';
import { ValueOption } from '../../models/valueOption';
import { ParameterFilter } from '../../models/enums/parameter-filter';

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

    remove(parameterId: number) {
        this.parameterService.delete(this.scriptId, parameterId)
            .subscribe((p: Parameter) =>
            {
                this.parameters = this.parameters.filter(p => p.id != parameterId)
                this.onParametersToShowChange();
                console.log("Parameters", p)
            }, error => console.error(error));
    }

    editParameter(parameter: Parameter) {
        this.editMode = true;
        this.newParameter = parameter;
    }
}