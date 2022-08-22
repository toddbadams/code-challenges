import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingPageRoutingModule } from './tasting-routing.module';
import { TastingPage } from './tasting.page';
import { WineStyleComponent } from 'src/app/components/wine-style/wine-style.component';
import { SwiperModule } from 'swiper/angular';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingPageRoutingModule,
    SwiperModule
  ],
  declarations: [TastingPage, WineStyleComponent]
})
export class TastingPageModule {}
