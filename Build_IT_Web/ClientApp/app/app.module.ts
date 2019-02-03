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
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';

import { HtmlPipeModule } from './pipes/html-pipe.module';

import { ScriptService } from './services/script.service';
import { TagService } from './services/tag.service';

@NgModule({
  declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      ScriptFormComponent,
      ScriptCalculatorComponent,
      HtmlPipeModule
  ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        HtmlPipeModule,
        AppRoutingModule
    ],
    providers: [
        ScriptService,
        TagService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
