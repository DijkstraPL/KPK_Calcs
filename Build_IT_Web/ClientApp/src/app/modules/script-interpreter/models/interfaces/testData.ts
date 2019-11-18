import { Assertion } from "./assertion";
import { TestParameter } from "./testParameter";

export interface TestData {
    id: number;
    scriptId: number;
    name: string;
    testParameters: TestParameter[];
    assertions: Assertion[];
}
