var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { AboutMeComponent } from './components/about-me/about-me.component';
import { AppErrorHandler } from './common/errors/app-error-handler';
import { LoadsRoutingModule } from './modules/loads/loads-routing.module';
import { LoadsModule } from './modules/loads/loads.module';
import { ScriptInterpreterModule } from './modules/script-interpreter/script-interpreter.module';
import { ScriptInterpreterRoutingModule } from './modules/script-interpreter/script-interpreter-routing.module';
import { MdComponentsModule } from './modules/md-components-module/md-components.module';
import { TranslationService, TranslateLanguageLoader } from './services/translation.service';
import { BootstrapSelectDirective } from './directives/bootstrap-select.directive';
import { LocalStoreManager } from './services/local-store-manager.service';
import { ConfigurationService } from './services/configuration.service';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                NavMenuComponent,
                HomeComponent,
                CarouselComponent,
                AboutMeComponent,
                BootstrapSelectDirective
            ],
            imports: [
                BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
                HttpClientModule,
                FormsModule,
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
                }),
            ],
            providers: [
                { provide: ErrorHandler, useClass: AppErrorHandler },
                TranslationService,
                LocalStoreManager,
                ConfigurationService
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map