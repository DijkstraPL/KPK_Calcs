import { NgModule } from '@angular/core';
import { HtmlPipe } from './text-pipes/html-pipe';

@NgModule({
    declarations: [
        HtmlPipe
    ],
    imports: [
    ],
    exports: [
        HtmlPipe
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
