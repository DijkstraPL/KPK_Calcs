import { Language } from "../../enums/language";

export interface GroupTranslation {
    id: number;
    groupId: number;
    name: string;
    language: Language;
}
