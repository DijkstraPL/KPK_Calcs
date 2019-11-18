import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DeadLoadsComponent } from './components/dead-loads-components/dead-loads/dead-loads.component';
import { SnowLoadsComponent } from './components/snow-loads-components/snow-loads/snow-loads.component';

const routes: Routes = [
    { path: 'deadloads', component: DeadLoadsComponent },
    { path: 'snowloads', component: SnowLoadsComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class LoadsRoutingModule {
}