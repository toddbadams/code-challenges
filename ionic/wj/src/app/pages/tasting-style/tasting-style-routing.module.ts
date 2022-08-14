import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingStylePage } from './tasting-style.page';

const routes: Routes = [
  {
    path: '',
    component: TastingStylePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingStylePageRoutingModule {}
