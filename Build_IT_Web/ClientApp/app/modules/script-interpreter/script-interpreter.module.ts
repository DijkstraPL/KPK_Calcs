import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomViewsModule } from '../custom-views-module/components/custom-views.module';
import { CustomViewsRoutingModule } from '../custom-views-module/components/custom-views-routing.module';

import { ScriptFormComponent } from './components/script-form/script-form.component';
import { ParametersFormComponent } from './components/script-form/parameters-form/parameters-form.component';
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';
import { DataParameterFormComponent } from './components/script-form/parameters-form/data-parameter-form/data-parameter-form.component';
import { ScriptCardComponent } from './components/script-card/script-card.component';
import { ScriptCardsComponent } from './components/script-cards/script-cards.component';
import { TagFormComponent } from './components/script-form/tag-form/tag-form.component';
import { ParameterInputComponent } from './components/script-calculator/parameter-inputs/input/parameter-input.component';
import { ParameterSelectComponent } from './components/script-calculator/parameter-inputs/select/parameter-select.component';
import { ParameterAutocompleteComponent } from './components/script-calculator/parameter-inputs/autocomplete/parameter-autocomplete.component';
import { ParameterRadioComponent } from './components/script-calculator/parameter-inputs/radio/parameter-radio.component';
import { ParameterFormComponent } from './components/script-calculator/parameter-inputs/parameters-form/parameter-form.component';
import { ParameterResultComponent } from './components/script-calculator/parameter-results/parameter-result/parameter-result.component';
import { ValueOptionsFormComponent } from './components/script-form/parameters-form/data-parameter-form/value-options-form/value-options-form.component';
import { ScriptDataFormComponent } from './components/script-form/script-data-form/script-data-form.component';
import { TranslationFormComponent } from './components/script-form/translation-form/translation-form.component';
import { ScriptTranslationFormComponent } from './components/script-form/translation-form/script-translation-form/script-translation-form.component';
import { ParameterTranslationFormComponent } from './components/script-form/translation-form/parameter-translation-form/parameter-translation-form.component';
import { ParameterCheckboxComponent } from './components/script-calculator/parameter-inputs/checkbox/parameter-checkbox.component';
import { FigureParameterFormComponent } from './components/script-form/parameters-form/data-parameter-form/figure-parameter-form/figure-parameter-form.component';
import { ParameterFiguresComponent } from './components/script-calculator/parameter-inputs/figures/parameter-figures.component';
import { ExistingFiguresDialogComponent } from './components/script-form/parameters-form/data-parameter-form/existing-figures-dialog/existing-figures-dialog.component';

import { ScriptService } from './services/script.service';
import { TagService } from './services/tag.service';
import { CalculationService } from './services/calculation.service';
import { ParameterService } from './services/parameter.service';
import { ParameterTranslationService } from './services/translations/parameter-translation.service';
import { ScriptTranslationService } from './services/translations/script-translation.service';

import { AppErrorHandler } from './../../common/errors/app-error-handler';

import { PipesModule } from '../pipes-module/pipes.module';
import { MdComponentsModule } from '../md-components-module/md-components.module';
import { FigureService } from './services/figure.service';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateLanguageLoader } from '../../services/translation.service';

@NgModule({
    declarations: [
        ScriptFormComponent,
        ParametersFormComponent,
        DataParameterFormComponent,
        ValueOptionsFormComponent,
        ScriptCalculatorComponent,
        ScriptCardComponent,
        ScriptCardsComponent,
        ScriptDataFormComponent,
        TagFormComponent,
        ParameterInputComponent,
        ParameterSelectComponent,
        ParameterAutocompleteComponent,
        ParameterRadioComponent,
        ParameterFormComponent,
        TranslationFormComponent,
        ParameterResultComponent,
        ParameterCheckboxComponent,
        FigureParameterFormComponent,
        ParameterFiguresComponent,
        ExistingFiguresDialogComponent,
        ScriptTranslationFormComponent,
        ParameterTranslationFormComponent
    ],
    imports: [
        PipesModule,
        CommonModule,
        RouterModule,
        HttpClientModule,
        FormsModule,
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
        ExistingFiguresDialogComponent
    ],
    exports: [
        ScriptCardsComponent
    ],
    providers: [
        ScriptService,
        TagService,
        CalculationService,
        ParameterService,
        FigureService, 
        ScriptTranslationService,
        ParameterTranslationService,
        { provide: ErrorHandler, useClass: AppErrorHandler }
    ]
})
export class ScriptInterpreterModule { }
