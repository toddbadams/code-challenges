import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingPageRoutingModule } from './tasting-routing.module';
import { TastingPage } from './tasting.page';
import { SwiperModule } from 'swiper/angular';
import { TastingPropertyComponent } from 'src/app/components/tasting-property/tasting-property.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingPageRoutingModule,
    SwiperModule
  ],
  declarations: [TastingPage, TastingPropertyComponent]
})
export class TastingPageModule {}
