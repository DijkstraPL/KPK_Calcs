import { Assertion } from "./interfaces/assertion";

export class AssertionImpl implements Assertion {
    id: number;
    value: string;
    testDataId: number;
}
