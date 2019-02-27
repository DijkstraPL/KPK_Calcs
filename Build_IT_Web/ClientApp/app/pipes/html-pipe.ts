import { NgModule, PipeTransform, Pipe } from '@angular/core';

@NgModule({})
@Pipe({ name: 'html' })
export class HtmlPipe implements PipeTransform {
    transform(html: string): string {
        if (!html)
            return "";

        let finalHtml = "";
        let inSubScript = false;
        let inSupScript = false;
        for (let i = 0; i < html.length; i++) {

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
    }
}