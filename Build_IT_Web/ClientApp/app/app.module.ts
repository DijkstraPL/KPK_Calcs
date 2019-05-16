import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';
import {MatAutocompleteModule} from '@angular/material/autocomplete';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';

import { AppErrorHandler } from './common/errors/app-error-handler';
import { LoadsRoutingModule } from './modules/loads/loads-routing.module';
import { LoadsModule } from './modules/loads/loads.module';
import { ScriptInterpreterModule } from './modules/script-interpreter/script-interpreter.module';
import { ScriptInterpreterRoutingModule } from './modules/script-interpreter/script-interpreter-routing.module';

@NgModule({
  declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent
  ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ScriptInterpreterRoutingModule,
        LoadsRoutingModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatCardModule,
        ReactiveFormsModule,
        MatAutocompleteModule,
        ScriptInterpreterModule,
        LoadsModule
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
