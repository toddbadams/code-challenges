import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
 
  // {
  //   path: 'welcome',
  //   loadChildren: () => import('./pages/welcome/home.module').then(m => m.HomePageModule)
  // },
  // {
  //   path: 'profile',
  //   loadChildren: () => import('./pages/profile/profile.module').then(m => m.ProfilePageModule)
  // },
  // {
  //   path: 'learn',
  //   loadChildren: () => import('./pages/learn/learn.module').then(m => m.LearnPageModule)
  // },
  {
    path: 'tastings',
    loadChildren: () => import('./pages/tastings/tastings.module').then(m => m.TastingsPageModule)
  },
  {
    path: 'tasting',
    loadChildren: () => import('./pages/tasting/tasting.module').then( m => m.TastingPageModule)
  },
  {
    path: '',
    redirectTo: 'tabs',
    pathMatch: 'full'
  },
  {
    path: 'tabs',
    loadChildren: () => import('./pages/tabs/tabs.module').then( m => m.TabsPageModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
