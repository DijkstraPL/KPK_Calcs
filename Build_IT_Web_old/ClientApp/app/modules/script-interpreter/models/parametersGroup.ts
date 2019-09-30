import { Parameter } from "./interfaces/parameter";

export class ParametersGroup  {

    name: string;
    parameters: Parameter[] = [];

    constructor(name: string) {
        this.name = name;
    }

    addParameter(parameter: Parameter) {
        this.parameters.push(parameter);
    }

    clear() {
        this.parameters = [];
    }
}