var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
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
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatRadioModule } from '@angular/material/radio';
import { ScriptFormComponent } from './components/script-form/script-form.component';
import { ParametersFormComponent } from './components/parameters-form/parameters-form.component';
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';
import { DataParametersFormComponent } from './components/parameters-form/data-parameters-form/data-parameters-form.component';
import { ScriptCardComponent } from './components/script-card/script-card.component';
import { ScriptCardsComponent } from './components/script-cards/script-cards.component';
import { TagFormComponent } from './components/script-form/tag-form/tag-form.component';
import { ParameterInputComponent } from './components/script-calculator/parameter-inputs/input/parameter-input.component';
import { ScriptService } from './services/script.service';
import { TagService } from './services/tag.service';
import { CalculationService } from './services/calculation.service';
import { ParameterService } from './services/parameter.service';
import { AppErrorHandler } from './../../common/errors/app-error-handler';
import { PipesModule } from '../pipes-module/pipes.module';
var ScriptInterpreterModule = /** @class */ (function () {
    function ScriptInterpreterModule() {
    }
    ScriptInterpreterModule = __decorate([
        NgModule({
            declarations: [
                ScriptFormComponent,
                ParametersFormComponent,
                DataParametersFormComponent,
                ScriptCalculatorComponent,
                ScriptCardComponent,
                ScriptCardsComponent,
                TagFormComponent,
                ParameterInputComponent
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
                MatButtonModule,
                MatInputModule,
                MatSelectModule,
                MatProgressBarModule,
                MatRadioModule
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
    ], ScriptInterpreterModule);
    return ScriptInterpreterModule;
}());
export { ScriptInterpreterModule };
//# sourceMappingURL=script-interpreter.module.js.map