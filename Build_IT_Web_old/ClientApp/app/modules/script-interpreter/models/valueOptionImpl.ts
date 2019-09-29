import { ValueOption } from "./interfaces/valueOption";

export class ValueOptionImpl implements ValueOption {
    id: number;
    name: string;
    value: string;
    description: string;
}