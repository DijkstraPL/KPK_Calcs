var CreateScriptCommand = /** @class */ (function () {
    function CreateScriptCommand(data) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    this[property] = data[property];
            }
        }
    }
    CreateScriptCommand.prototype.init = function (data) {
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
    };
    CreateScriptCommand.fromJS = function (data) {
        data = typeof data === 'object' ? data : {};
        var result = new CreateScriptCommand();
        result.init(data);
        return result;
    };
    CreateScriptCommand.prototype.toJSON = function (data) {
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
    };
    return CreateScriptCommand;
}());
export { CreateScriptCommand };
//# sourceMappingURL=create-script-command.js.map