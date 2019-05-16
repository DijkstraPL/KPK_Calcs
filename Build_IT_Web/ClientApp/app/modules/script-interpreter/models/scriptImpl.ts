import { Tag } from "./interfaces/tag";
import { Script } from "./interfaces/script";
import { TagImpl } from "./tagImpl";

export class ScriptImpl implements Script {
    id: number;
    name: string;
    description: string;
    groupName: string;
    author: string;
    added: Date;
    version: number;
    modified: Date;
    accordingTo: string;
    notes: string;
    tags: Tag[] = [];

}