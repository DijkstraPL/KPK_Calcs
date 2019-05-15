import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadsRoutingModule } from './loads-routing.module';
import { DeadLoadsCalculatorComponent } from './components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
    declarations: [
        DeadLoadsCalculatorComponent
    ],
  imports: [
      CommonModule,
      LoadsRoutingModule,
      FormsModule,
      MatSelectModule,
      MatTableModule,
      MatButtonModule,
      MatInputModule,
      MatCheckboxModule
  ]
})
export class LoadsModule { }
