import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TastingPageRoutingModule } from './tasting-routing.module';

import { TastingPage } from './tasting.page';
import { TastingAppearanceComponent } from './tasting-appearance/tasting-appearance.component';
import { TastingNoseComponent } from './tasting-nose/tasting-nose.component';
import { TastingRangeComponent } from './tasting-range/tasting-range.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingPageRoutingModule
  ],
  declarations: [TastingPage, TastingAppearanceComponent, TastingNoseComponent, TastingRangeComponent]
})
export class TastingPageModule {}
