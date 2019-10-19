import { ParameterOptions } from "../enums/parameterOptions";
import { ValueOptionSettings } from "../enums/valueOptionSettings";
import { ValueType } from "../enums/valueType";
import { Figure } from "./figure";
import { Group } from "./group";
import { ValueOption } from "./valueOption";

export interface Parameter {
    id: number;
    name: string;
    number: number;
    description: string;
    valueType: ValueType;
    value: string;
    visibilityValidator: string;
    dataValidator: string;
    unit: string;
    context: ParameterOptions;
    accordingTo: string;
    notes: string;
    valueOptionSetting: ValueOptionSettings;
    valueOptions: ValueOption[];
    figures: Figure[];
    group: Group;
    groupId: number | null;

    equation: string;
}
