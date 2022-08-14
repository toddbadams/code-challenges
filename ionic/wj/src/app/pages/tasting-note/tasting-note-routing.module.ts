import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TastingNotePage } from './tasting-note.page';

const routes: Routes = [
  {
    path: '',
    component: TastingNotePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TastingNotePageRoutingModule {}
