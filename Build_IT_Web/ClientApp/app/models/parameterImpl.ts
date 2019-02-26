import { AlternativeScript } from "./alternativeScript";
import { ValueOption } from "./valueOption";
import { ValueType } from "./valueType";
import { ParameterOptions } from "./parameterOptions";
import { ValueOptionSettings } from "./valueOptionSettings";
import { Parameter } from "./parameter";

export class ParameterImpl implements Parameter {
    id: number;
    name: string;
    number: number;
    description: string;
    valueType: ValueType = ValueType.number;
    value: string;
    dataValidator: string;
    unit: string;
    context: ParameterOptions;
    groupName: string;
    accordingTo: string;
    notes: string;
    valueOptionSetting: ValueOptionSettings;
    nestedScripts: AlternativeScript[];
    valueOptions: ValueOption[] = [];
}