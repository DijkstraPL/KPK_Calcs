import { LoadUnit } from "../enums/loadUnit";
import { Addition } from "./addition";

export interface Material {
    name: string;
    maximumDensity: number;
    minimumDensity: number;
    unit: LoadUnit;
    documentName: string;
    comments: string;

    additions: Addition[];
}