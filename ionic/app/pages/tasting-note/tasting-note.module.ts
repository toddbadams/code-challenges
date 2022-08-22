import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingNotePageRoutingModule } from './tasting-note-routing.module';
import { TastingNotePage } from 'src/app/pages/tasting-note/tasting-note.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingNotePageRoutingModule
  ],
  declarations: [TastingNotePage]
})
export class TastingNotePageModule {}
