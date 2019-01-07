import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ScriptsFormComponent } from './components/scripts-form/scripts-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch:'full' },
  { path: 'scripts/new', component: ScriptsFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
