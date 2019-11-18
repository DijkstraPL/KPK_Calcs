import { Addition } from "./interfaces/addition";

export class AdditionForCalculations {
    origin: Addition;
    isChecked: boolean;

    constructor(addition: Addition) {
        this.origin = addition;
    }
}