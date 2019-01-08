import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ScriptFormComponent } from './components/script-form/script-form.component';
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';

import { ScriptService } from './services/script.service';

@NgModule({
  declarations: [
      AppComponent,
      NavMenuComponent,
      ScriptFormComponent,
      ScriptCalculatorComponent
  ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
      AppRoutingModule
    ],
    providers: [ScriptService],
  bootstrap: [AppComponent]
})
export class AppModule { }
