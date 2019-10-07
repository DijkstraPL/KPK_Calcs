import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { AboutMeComponent } from './components/about-me/about-me.component';
import { LoginComponent } from './components/login/login.component';

import { AppErrorHandler } from './common/errors/app-error-handler';
import { LoadsRoutingModule } from './modules/loads/loads-routing.module';
import { LoadsModule } from './modules/loads/loads.module';
import { ScriptInterpreterModule } from './modules/script-interpreter/script-interpreter.module';
import { ScriptInterpreterRoutingModule } from './modules/script-interpreter/script-interpreter-routing.module';
import { CustomViewsModule } from './modules/custom-views-module/components/custom-views.module';
import { CustomViewsRoutingModule } from './modules/custom-views-module/components/custom-views-routing.module';
import { MdComponentsModule } from './modules/md-components-module/md-components.module';
import { TranslationService, TranslateLanguageLoader } from './services/translation.service';
import { ElementSelectDirective } from './directives/element-select.directive';
import { LocalStoreManager } from './services/local-store-manager.service';
import { ConfigurationService } from './services/configuration.service';
import { SearchService } from './services/search.service';

import { AuthService } from './services/auth.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { AuthResponseInterceptor } from './services/auth.response.interceptor';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      CarouselComponent,
      AboutMeComponent,
      ElementSelectDirective,
      LoginComponent,
      RegisterComponent
  ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        CustomViewsModule,
        CustomViewsRoutingModule,
        ScriptInterpreterRoutingModule,
        LoadsRoutingModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        ScriptInterpreterModule,
        LoadsModule,
        MdComponentsModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useClass: TranslateLanguageLoader
            }
        })
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        AuthService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthResponseInterceptor,
            multi: true
        },
        TranslationService,
        LocalStoreManager,
        ConfigurationService,
        SearchService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}