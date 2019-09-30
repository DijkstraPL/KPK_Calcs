import { NgModule } from '@angular/core';
import { HtmlPipe } from './text-pipes/html-pipe';
import { ToNumberPipe } from './text-pipes/toNumber-pipe';

@NgModule({
    declarations: [
        HtmlPipe,
        ToNumberPipe
    ],
    imports: [
    ],
    exports: [
        HtmlPipe,
        ToNumberPipe
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
