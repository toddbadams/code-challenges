import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { WineStylePageRoutingModule } from './wine-style-routing.module';

import { WineStylePage } from './wine-style.page';
import { WineStyleComponent } from 'src/app/components/wine-style/wine-style.component';
import { SwiperModule } from 'swiper/angular';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    WineStylePageRoutingModule,
    SwiperModule
  ],
  declarations: [WineStylePage, WineStyleComponent]
})
export class WineStylePageModule {}
