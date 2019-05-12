import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeadLoadsCalculatorComponent } from '../loads/components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component';
import { DeadLoadsService } from '../loads/services/dead-loads.service';

@NgModule({
    declarations: [
        DeadLoadsCalculatorComponent
    ],
  imports: [
    CommonModule
    ],
    providers: [
        DeadLoadsService
        ]
})
export class ScriptInterpreterModule { }
