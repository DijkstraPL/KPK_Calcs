import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DeadLoadsCalculatorComponent } from './components/dead-loads-components/dead-loads-calculator/dead-loads-calculator.component';

const routes: Routes = [
    { path: 'deadloads', component: DeadLoadsCalculatorComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class LoadsRoutingModule {
}