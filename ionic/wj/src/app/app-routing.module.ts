import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
{
  path: 'home',
  loadChildren: () => import('./pages/home/home.module').then( m => m.HomePageModule)
},
  {
    path: 'tasting',
    loadChildren: () => import('./pages/tasting/tasting.module').then( m => m.TastingPageModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
