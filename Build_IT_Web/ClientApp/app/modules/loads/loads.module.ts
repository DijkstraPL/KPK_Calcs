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

@NgModule({
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
export class LoadsModule { }
