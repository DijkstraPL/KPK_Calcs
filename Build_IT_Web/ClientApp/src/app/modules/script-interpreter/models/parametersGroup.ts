import { Parameter } from "./interfaces/parameter";
import { Group } from "./interfaces/group";

export class ParametersGroup  {
    group: Group;
    parameters: Parameter[] = [];

    constructor(group: Group) {
        this.group = group;
    }

    addParameter(parameter: Parameter) {
        this.parameters.push(parameter);
    }

    clear() {
        this.parameters = [];
    }
}
