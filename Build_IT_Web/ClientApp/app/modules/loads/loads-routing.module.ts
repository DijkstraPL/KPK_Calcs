import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DeadLoadsComponent } from './components/dead-loads-components/dead-loads/dead-loads.component';

const routes: Routes = [
    { path: 'deadloads', component: DeadLoadsComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class LoadsRoutingModule {
}