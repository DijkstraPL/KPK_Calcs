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

@NgModule({
    declarations: [
    ],
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
export class MdComponentsModule { }
