import { Language } from "../../enums/language";

export interface ParameterTranslation {
    id: number;
    parameterId: number;
    groupName: string;
    description: string;  
    notes: string;   
    language: Language;
}