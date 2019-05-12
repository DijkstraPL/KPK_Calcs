import { LoadUnit } from "../enums/loadUnit";

export interface Material {
    name: string;
    maximumDensity: number;
    minimumDensity: number;
    unit: LoadUnit;
    documentName: string;
    comments: string;
}