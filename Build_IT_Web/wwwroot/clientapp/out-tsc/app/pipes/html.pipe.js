var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Pipe } from "@angular/core";
var HtmlPipe = /** @class */ (function () {
    function HtmlPipe() {
    }
    HtmlPipe.prototype.transform = function (html) {
        var finalHtml = "";
        var inSubScript = false;
        var inSupScript = false;
        for (var i = 0; i < html.length; i++) {
            if (html[i] == "_" && !inSubScript) {
                finalHtml += "<sub>";
                inSubScript = true;
            }
            else if (html[i] == "_" && inSubScript) {
                finalHtml += "</sub>";
                inSubScript = false;
            }
            else if (html[i] == "^" && !inSupScript) {
                finalHtml += "<sup>";
                inSupScript = true;
            }
            else if (html[i] == "^" && inSupScript) {
                finalHtml += "</sup>";
                inSupScript = false;
            }
            else
                finalHtml += html[i];
        }
        return finalHtml;
    };
    HtmlPipe = __decorate([
        Pipe({ name: 'html' })
    ], HtmlPipe);
    return HtmlPipe;
}());
export { HtmlPipe };
//# sourceMappingURL=html.pipe.js.map