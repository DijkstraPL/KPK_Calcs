import { ValueOption } from "./interfaces/valueOption";

export class ValueOptionImpl implements ValueOption {
    id: number;
    value: string;
    description: string;
}