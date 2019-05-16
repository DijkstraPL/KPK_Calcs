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
import { DragDropModule } from '@angular/cdk/drag-drop';
import { DeadLoadsDataComponent } from './components/dead-loads-components/dead-loads-data/dead-loads-data.component';
import { DeadLoadsComponent } from './components/dead-loads-components/dead-loads/dead-loads.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
      MatSelectModule,
      MatTableModule,
      MatButtonModule,
      MatInputModule,
      MatCheckboxModule,
      BrowserAnimationsModule,
      DragDropModule
  ]
})
export class LoadsModule { }
