import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SnowLoadMonopitchRoofComponent } from './snow-load-monopitch-roof/snow-load-monopitch-roof.component';

const routes: Routes = [
    { path: 'scripts/custom/10/1', component: SnowLoadMonopitchRoofComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class CustomViewsRoutingModule {
}