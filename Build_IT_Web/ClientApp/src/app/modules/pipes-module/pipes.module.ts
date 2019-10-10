import { NgModule } from '@angular/core';
import { HtmlPipe } from './text-pipes/html-pipe';
import { ToNumberPipe } from './text-pipes/toNumber-pipe';
import { SafeHtmlPipe } from './text-pipes/safe-html-pipe';

@NgModule({
    declarations: [
        HtmlPipe,
        ToNumberPipe,
        SafeHtmlPipe
    ],
    imports: [
    ],
    exports: [
        HtmlPipe,
        ToNumberPipe,
        SafeHtmlPipe
    ]
})
export class PipesModule {
    //static forRoot() {
    //    return {
    //        ngModule: PipesModule,
    //        providers: [],
    //    };
    //}
}
