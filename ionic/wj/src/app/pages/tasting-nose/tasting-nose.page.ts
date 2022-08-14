import { Component, OnInit } from '@angular/core';
import { SegmentCustomEvent } from '@ionic/angular';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'wj-tasting-nose',
  templateUrl: './tasting-nose.page.html',
  styleUrls: ['./tasting-nose.page.scss'],
})
export class TastingNosePage implements OnInit {
  stepper: TastingStepper;
  currentTab: string;

  constructor(private tastingsService: TastingsService, private router: Router) { }

  ngOnInit() {
    this.stepper = this.tastingsService.getStepper();
    this.currentTab = 'structure';
    if (!environment.production)
      console.log("TastingNosePage ngOnInit: ", this.stepper);
      if (!this.stepper.tasting) this.router.navigate(['/tasting']);
  }

  setCurrentTab($event: Event) {
    if (!environment.production)
      console.log("TastingNosePage setCurrentTab: ", $event);
    this.currentTab = ($event as SegmentCustomEvent).detail.value;
  }

  changeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose changeEvent: ", $event, this.stepper);
    this.stepper.tasting.nose.write();
  }
}
