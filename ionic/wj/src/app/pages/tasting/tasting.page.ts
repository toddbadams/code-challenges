import { Component, OnInit, ViewChild } from '@angular/core';
import { IonTabs } from '@ionic/angular';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'wj-tasting',
  templateUrl: './tasting.page.html',
  styleUrls: ['./tasting.page.scss'],
})
export class TastingPage implements OnInit {
  stepper: TastingStepper;
  @ViewChild('tabs') tabs: IonTabs;

  constructor(private tastingsService: TastingsService) { }

  ngOnInit() {
    this.tastingsService.getTastingSystem().subscribe(x => {
      this.stepper = this.tastingsService.createStepper(x);
      if (!environment.production)
        console.log("wj-tasting-stepper ngOnInit: ", this.stepper);
    });
  }

  setCurrentTab($event: any) {
    if (!environment.production)
      console.log("wj-tasting-stepper setCurrentTab: ", $event);
    this.stepper.setCurrentTab($event.tab);
  }

  save() {
    this.tastingsService.createTasting(this.stepper.tasting)
      .then(d => {
        if (!environment.production)
          console.log("wj-tasting-stepper save: ", (d as any)._key.path.segments);
      })
      .catch(error => {
        console.log(error);
      });
  }
}
