import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WineStylePage } from './wine-style.page';

const routes: Routes = [
  {
    path: '',
    component: WineStylePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WineStylePageRoutingModule {}
