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
import { ScriptInterpreterModule } from '../script-interpreter/script-interpreter.module';
import { SnowLoadsComponent } from './components/snow-loads-components/snow-loads/snow-loads.component';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateLanguageLoader } from '../../services/translation.service';

@NgModule({
    declarations: [
        DeadLoadsComponent,
        DeadLoadsCalculatorComponent,
        DeadLoadsDataComponent,
        SnowLoadsComponent
    ],
  imports: [
      CommonModule,
      LoadsRoutingModule,
      FormsModule,
      MdComponentsModule,
      BrowserAnimationsModule,
      DragDropModule,
      ScriptInterpreterModule,
      TranslateModule.forRoot({
          loader: {
              provide: TranslateLoader,
              useClass: TranslateLanguageLoader
          }
      })
  ]
})
export class LoadsModule { }
