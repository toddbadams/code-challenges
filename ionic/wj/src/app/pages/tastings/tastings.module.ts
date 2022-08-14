import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingsPageRoutingModule } from './tastings-routing.module';
import { TastingsPage } from './tastings.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingsPageRoutingModule
  ],
  declarations: [TastingsPage]
})
export class TastingsPageModule {}
