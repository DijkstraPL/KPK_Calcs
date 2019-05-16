import { Tag } from "./tag";

export interface Script {
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
    tags: Tag[];
}