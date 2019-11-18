import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateLanguageLoader } from '../../../services/translation.service';
import { MdComponentsModule } from '../../md-components-module/md-components.module';
import { PipesModule } from '../../pipes-module/pipes.module';
import { ScriptInterpreterModule } from '../../script-interpreter/script-interpreter.module';

import { SnowLoadMonopitchRoofComponent } from './snow-load-monopitch-roof/snow-load-monopitch-roof.component';

import { AppErrorHandler } from '../../../common/errors/app-error-handler';

@NgModule({
    declarations: [
        SnowLoadMonopitchRoofComponent
    ],
    imports: [
        PipesModule,
        CommonModule,
        RouterModule,
        HttpClientModule,
        FormsModule,
        ScriptInterpreterModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        MdComponentsModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useClass: TranslateLanguageLoader
            }
        })
    ],
    entryComponents: [
    ],
    exports: [
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler }
    ]
})
export class CustomViewsModule { }
