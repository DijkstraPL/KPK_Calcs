import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadsRoutingModule } from './loads-routing.module';
import { DeadLoadsCalculatorComponent } from './components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        DeadLoadsCalculatorComponent
    ],
  imports: [
      CommonModule,
      LoadsRoutingModule,
      FormsModule
  ]
})
export class LoadsModule { }
