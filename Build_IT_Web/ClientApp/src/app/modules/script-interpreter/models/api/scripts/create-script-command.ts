import { Language } from "../../enums/language";

export interface ICreateScriptCommand {
    id?: number | undefined;
    name?: string | undefined;
    description?: string | undefined;
    groupName?: string | undefined;
    author?: string | undefined;
    accordingTo?: string | undefined;
    notes?: string | undefined;
    defaultLanguage?: Language | undefined;
}

export class CreateScriptCommand implements ICreateScriptCommand {
    id?: number | undefined;
    name?: string | undefined;
    description?: string | undefined;
    groupName?: string | undefined;
    author?: string | undefined;
    accordingTo?: string | undefined;
    notes?: string | undefined;
    defaultLanguage?: Language | undefined;

    constructor(data?: ICreateScriptCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = 0;
            this.name = data["name"];
            this.description = data["description"];
            this.groupName = data["groupName"];
            this.author = data["author"];
            this.accordingTo = data["accordingTo"];
            this.notes = data["notes"];
            this.defaultLanguage = data["defaultLanguage"];
        }
    }
        
    static fromJS(data: any): CreateScriptCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateScriptCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["description"] = this.description;
        data["groupName"] = this.groupName;
        data["author"] = this.author;
        data["accordingTo"] = this.accordingTo;
        data["notes"] = this.notes;
        data["defaultLanguage"] = this.defaultLanguage;
        return data;
    }
}