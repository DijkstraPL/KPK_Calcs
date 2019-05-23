var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadsRoutingModule } from './loads-routing.module';
import { DeadLoadsCalculatorComponent } from './components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component';
import { FormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { DeadLoadsDataComponent } from './components/dead-loads-components/dead-loads-data/dead-loads-data.component';
import { DeadLoadsComponent } from './components/dead-loads-components/dead-loads/dead-loads.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MdComponentsModule } from '../md-components-module/md-components.module';
var LoadsModule = /** @class */ (function () {
    function LoadsModule() {
    }
    LoadsModule = __decorate([
        NgModule({
            declarations: [
                DeadLoadsComponent,
                DeadLoadsCalculatorComponent,
                DeadLoadsDataComponent,
            ],
            imports: [
                CommonModule,
                LoadsRoutingModule,
                FormsModule,
                MdComponentsModule,
                BrowserAnimationsModule,
                DragDropModule
            ]
        })
    ], LoadsModule);
    return LoadsModule;
}());
export { LoadsModule };
//# sourceMappingURL=loads.module.js.map