var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatRadioModule } from '@angular/material/radio';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { MatChipsModule } from '@angular/material/chips';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserModule } from '@angular/platform-browser';
var MdComponentsModule = /** @class */ (function () {
    function MdComponentsModule() {
    }
    MdComponentsModule = __decorate([
        NgModule({
            declarations: [],
            exports: [
                CommonModule,
                MatSelectModule,
                MatTableModule,
                MatButtonModule,
                MatInputModule,
                MatCheckboxModule,
                BrowserModule,
                BrowserAnimationsModule,
                DragDropModule,
                MatCardModule,
                MatAutocompleteModule,
                MatProgressBarModule,
                MatRadioModule,
                MatExpansionModule,
                MatListModule,
                MatTabsModule,
                MatChipsModule,
                MatToolbarModule,
                MatPaginatorModule
            ]
        })
    ], MdComponentsModule);
    return MdComponentsModule;
}());
export { MdComponentsModule };
//# sourceMappingURL=md-components.module.js.map