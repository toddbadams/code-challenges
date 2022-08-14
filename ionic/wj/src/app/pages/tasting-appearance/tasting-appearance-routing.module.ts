import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingAppearancePage } from './tasting-appearance.page';

const routes: Routes = [
  {
    path: '',
    component: TastingAppearancePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingAppearancePageRoutingModule {}
