import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import SwiperCore, { SwiperOptions, EffectFade, } from 'swiper';

SwiperCore.use([EffectFade]);

@Component({
  selector: 'wj-wine-style',
  templateUrl: './wine-style.component.html',
  styleUrls: ['./wine-style.component.scss'],
})
export class WineStyleComponent implements OnInit {
  config: SwiperOptions = {
    slidesPerView: 2.5,
    spaceBetween: 10,
    navigation: false,
    pagination: { type: 'fraction' },
    scrollbar: { draggable: true }
  };
  constructor() { }

  ngOnInit() { }

  onSlideChange() {
    if (!environment.production)
      console.log("wj-wine-style onSlideChange");
  }

  onSwiper($event: any) {
    if (!environment.production)
      console.log("wj-wine-style onSwiper: ", $event);
  }
}
