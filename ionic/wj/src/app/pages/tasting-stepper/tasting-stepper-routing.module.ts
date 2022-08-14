import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingStepperPage } from './tasting-stepper.page';

const routes: Routes = [
  {
    path: '',
    component: TastingStepperPage,
    children: [
      {
        path: 'style',
        loadChildren: () => import('src/app/pages/tasting-style/tasting-style.module').then(m => m.TastingStylePageModule)
      },
      {
        path: 'appearance',
        loadChildren: () => import('src/app/pages/tasting-appearance/tasting-appearance.module').then(m => m.TastingAppearancePageModule)
      },
      {
        path: 'nose',
        loadChildren: () => import('src/app/pages/tasting-nose/tasting-nose.module').then(m => m.TastingNosePageModule)
      },
      {
        path: 'palate',
        loadChildren: () => import('src/app/pages/tasting-palate/tasting-palate.module').then(m => m.TastingPalatePageModule)
      },
      {
        path: 'conclusion',
        loadChildren: () => import('src/app/pages/tasting-conclusion/tasting-conclusion.module').then(m => m.TastingConclusionPageModule)
      },
      {
        path: 'details',
        loadChildren: () => import('src/app/pages/tasting-details/tasting-details.module').then(m => m.TastingDetailsPageModule)
      },
      {
        path: 'note',
        loadChildren: () => import('src/app/pages/tasting-note/tasting-note.module').then(m => m.TastingNotePageModule)
      },
      {
        path: '',
        redirectTo: '/tasting/style',
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingStepperPageRoutingModule { }
