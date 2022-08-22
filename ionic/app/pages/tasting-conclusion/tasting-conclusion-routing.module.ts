import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingConclusionPage } from './tasting-conclusion.page';

const routes: Routes = [
  {
    path: '',
    component: TastingConclusionPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingConclusionPageRoutingModule {}
