import { TestParameter } from "./interfaces/testParameter";
import { Assertion } from "./interfaces/assertion";

export class TestParameterImpl implements TestParameter {

    id: number;
    value: string;
    testDataId: number;
    parameterId: number;

    constructor(parameterId: number, testDataId: number) {
        this.parameterId = parameterId;
        this.testDataId = testDataId;
    }
}
