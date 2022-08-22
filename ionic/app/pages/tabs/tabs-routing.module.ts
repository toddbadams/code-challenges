import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: '',
    component: TabsPage,
    children: [
      {
        path: 'learn',
        loadChildren: () => import('src/app/pages/learn/learn.module').then( m => m.LearnPageModule)
      },
      {
        path: 'profile',
        loadChildren: () => import('src/app/pages/profile/profile.module').then( m => m.ProfilePageModule)
      },
      {
        path: 'tastings',
        loadChildren: () => import('src/app/pages/tastings/tastings.module').then( m => m.TastingsPageModule)
      },
      {
        path: '',
        redirectTo: '/tabs/tastings',
        pathMatch: 'full'
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TabsPageRoutingModule {}
