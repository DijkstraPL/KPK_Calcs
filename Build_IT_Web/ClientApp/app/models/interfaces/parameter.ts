import { AlternativeScript } from "./alternativeScript";
import { ValueOption } from "./valueOption";
import { ValueType } from "../enums/valueType";
import { ParameterOptions } from "../enums/parameterOptions";
import { ValueOptionSettings } from "../enums/valueOptionSettings";

export interface Parameter {
    id: number;
    name: string;
    number: number;
    description: string;
    valueType: ValueType;
    value: string;
    dataValidator: string;
    unit: string;
    context: ParameterOptions;
    groupName: string;
    accordingTo: string;
    notes: string;
    valueOptionSetting: ValueOptionSettings;
    nestedScripts: AlternativeScript[];
    valueOptions: ValueOption[];

    equation: string;
}