import { TestParameter } from "./interfaces/testParameter";
import { Assertion } from "./interfaces/assertion";
import { TestData } from "./interfaces/testData";

export class TestDataImpl implements TestData {
    id: number;
    scriptId: number;
    name: string;
    testParameters: TestParameter[];
    assertions: Assertion[];

    constructor() {
        this.testParameters = [];
        this.assertions = [];
    }
}
