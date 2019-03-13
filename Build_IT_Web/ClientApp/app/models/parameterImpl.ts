import { AlternativeScript } from "./interfaces/alternativeScript";
import { ValueOption } from "./interfaces/valueOption";
import { ValueType } from "./enums/valueType";
import { ParameterOptions } from "./enums/parameterOptions";
import { ValueOptionSettings } from "./enums/valueOptionSettings";
import { Parameter } from "./interfaces/parameter";

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
    
    equation: string;
}