import { Language } from "../../enums/language";

export interface ScriptTranslation {
    id: number;
    scriptId: number;
    name: string;
    description: string;  
    notes: string;   
    language: Language;
}