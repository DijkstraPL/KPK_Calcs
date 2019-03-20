import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ScriptFormComponent } from './components/script-form/script-form.component';
import { ParametersFormComponent } from './components/parameters-form/parameters-form.component';
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';
import { DataParametersFormComponent } from './components/parameters-form/data-parameters-form/data-parameters-form.component';
import { ScriptCardComponent } from './components/script-card/script-card.component';
import { ScriptCardsComponent } from './components/script-cards/script-cards.component';

import { HtmlPipe } from './pipes/html-pipe';

import { ScriptService } from './services/script.service';
import { TagService } from './services/tag.service';
import { CalculationService } from './services/calculation.service';
import { ParameterService } from './services/parameter.service';
import { TagFormComponent } from './components/script-form/tag-form/tag-form.component';

@NgModule({
  declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      ScriptFormComponent,
      ParametersFormComponent,
      DataParametersFormComponent,
      ScriptCalculatorComponent,
      ScriptCardComponent,
      ScriptCardsComponent,
      TagFormComponent,
      HtmlPipe
  ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        HtmlPipe,
        AppRoutingModule
    ],
    providers: [
        ScriptService,
        TagService,
        CalculationService,
        ParameterService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
