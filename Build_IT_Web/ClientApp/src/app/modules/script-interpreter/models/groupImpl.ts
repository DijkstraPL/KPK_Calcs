import { Group } from "./interfaces/group";

export class GroupImpl implements Group {
    id: number;
    name: string;  
    visibilityValidator: string;

    constructor() {
        this.id = 0;
    }
}
