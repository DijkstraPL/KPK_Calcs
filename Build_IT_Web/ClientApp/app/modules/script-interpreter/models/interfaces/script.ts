import { Tag } from "./tag";
import { Language } from "../enums/language";

export interface Script {
    id: number;
    name: string;
    description: string;
    groupName: string;
    author: string;
    added: Date;
    version: string;
    modified: Date;
    accordingTo: string;
    notes: string;
    tags: Tag[];
    defaultLanguage: Language;
}