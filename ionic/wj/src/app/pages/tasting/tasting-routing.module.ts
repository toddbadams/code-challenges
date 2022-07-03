import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TastingPage } from './tasting.page';

const routes: Routes = [
  {
    path: '',
    component: TastingPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingPageRoutingModule {}
