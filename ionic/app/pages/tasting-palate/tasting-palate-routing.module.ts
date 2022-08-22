import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingPalatePage } from './tasting-palate.page';

const routes: Routes = [
  {
    path: '',
    component: TastingPalatePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingPalatePageRoutingModule {}
