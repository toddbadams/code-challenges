import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TastingDetailsPage } from './tasting-details.page';

const routes: Routes = [
  {
    path: '',
    component: TastingDetailsPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingDetailsPageRoutingModule {}
