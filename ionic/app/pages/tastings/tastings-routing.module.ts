import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TastingsPage } from './tastings.page';

const routes: Routes = [
  {
    path: '',
    component: TastingsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingsPageRoutingModule {}
