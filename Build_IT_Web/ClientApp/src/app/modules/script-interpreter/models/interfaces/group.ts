import { Parameter } from "./parameter";

export interface Group {
    id: number;
    name: string;
    visibilityValidator: string;   
    parameters: Parameter[];
}
