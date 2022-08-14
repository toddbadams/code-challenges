import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingNosePage } from './tasting-nose.page';

const routes: Routes = [
  {
    path: '',
    component: TastingNosePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingNosePageRoutingModule {}
