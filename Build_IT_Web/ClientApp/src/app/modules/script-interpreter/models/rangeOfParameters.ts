import { Parameter } from "./interfaces/parameter";

export class RangeOfParameters {
    parameterId: number;
    parameters: Parameter[];

    minValue: number;
    maxValue: number;
    tick: number;
}
