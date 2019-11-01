import { Tag } from "./tag";
import { Language } from "../enums/language";

export interface TestParameter {
    id: number;
    value: string;
    testDataId: number;
    parameterId: number;
}
