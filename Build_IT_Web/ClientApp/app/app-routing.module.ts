import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { ScriptFormComponent } from './components/script-form/script-form.component';
import { ScriptCalculatorComponent } from './components/script-calculator/script-calculator.component';

const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'scripts/new', component: ScriptFormComponent },
    { path: 'scripts/edit/:id', component: ScriptFormComponent },
    { path: 'scripts/calculator/:id', component: ScriptCalculatorComponent },
    { path: 'scripts/calculator', component: ScriptCalculatorComponent },
    { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
