import { Language } from "./enums/language";
import { Script } from "./interfaces/script";
import { Tag } from "./interfaces/tag";

export class ScriptImpl implements Script {
    id: number;
    name: string;
    description: string;
    groupName: string;
    added: Date;
    version: string;
    modified: Date;
    accordingTo: string;
    notes: string;
    tags: Tag[] = [];
    defaultLanguage: Language;
    isPublic: boolean;
}
