import { Language } from "../../enums/language";

export interface ValueOptionTranslation {
    id: number;
    valueOptionId: number;
    name: string;
    description: string;  
    language: Language;
}