import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';

import { ScriptFormComponent } from './components/script-form/script-form.component';
import { ParametersFormComponent } from './components/parameters-form/parameters-form.component';
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';
import { DataParametersFormComponent } from './components/parameters-form/data-parameters-form/data-parameters-form.component';
import { ScriptCardComponent } from './components/script-card/script-card.component';
import { ScriptCardsComponent } from './components/script-cards/script-cards.component';
import { TagFormComponent } from './components/script-form/tag-form/tag-form.component';

import { ScriptService } from './services/script.service';
import { TagService } from './services/tag.service';
import { CalculationService } from './services/calculation.service';
import { ParameterService } from './services/parameter.service';

import { AppErrorHandler } from './../../common/errors/app-error-handler';

import { PipesModule } from '../pipes-module/pipes.module';

@NgModule({
    declarations: [
        ScriptFormComponent,
        ParametersFormComponent,
        DataParametersFormComponent,
        ScriptCalculatorComponent,
        ScriptCardComponent,
        ScriptCardsComponent,
        TagFormComponent
    ],
    imports: [
        PipesModule,
        CommonModule,
        RouterModule,
        HttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatCardModule,
        ReactiveFormsModule,
        MatAutocompleteModule,
        MatButtonModule
    ],
    exports: [
        ScriptCardsComponent
    ],
    providers: [
        ScriptService,
        TagService,
        CalculationService,
        ParameterService,
        { provide: ErrorHandler, useClass: AppErrorHandler }
    ]
})
export class ScriptInterpreterModule { }
