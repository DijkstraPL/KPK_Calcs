import { TestParameter } from "./interfaces/testParameter";

export class TestDataImpl implements TestParameter {
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
