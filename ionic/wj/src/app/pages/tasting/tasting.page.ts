import { Component, OnInit, ViewChild } from '@angular/core';
import { IonTabs } from '@ionic/angular';
import { Tasting } from 'src/app/models/tasting/Tasting';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';
import SwiperCore, { SwiperOptions, EffectFade, } from 'swiper';

@Component({
  selector: 'wj-tasting',
  templateUrl: './tasting.page.html',
  styleUrls: ['./tasting.page.scss'],
})
export class TastingPage implements OnInit {
  tasting: Tasting;
  config: SwiperOptions = {
    slidesPerView: 1,
    spaceBetween: 10,
    navigation: false,
    pagination: { type: 'fraction' },
    scrollbar: { draggable: true }
  };

  @ViewChild('tabs') tabs: IonTabs;

  constructor(private tastingsService: TastingsService) { }

  ngOnInit() {
    this.tastingsService.getTastingSystem().subscribe(x => {
      this.tasting = new Tasting(x);
      if (!environment.production)
        console.log("wj-tasting ngOnInit: ", this.tasting);
    });
  }

  onSlideChange() {
    if (!environment.production)
      console.log("wj-wine-style onSlideChange");
  }

  onSwiper($event: any) {
    if (!environment.production)
      console.log("wj-wine-style onSwiper: ", $event);
  }


  save() {
    // this.tastingsService.createTasting(this.stepper.tasting)
    //   .then(d => {
    //     if (!environment.production)
    //       console.log("wj-tasting-stepper save: ", (d as any)._key.path.segments);
    //   })
    //   .catch(error => {
    //     console.log(error);
    //   });
  }
}
