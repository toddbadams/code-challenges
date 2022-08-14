import { Component, OnInit } from '@angular/core';
import { SegmentCustomEvent } from '@ionic/angular';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'wj-tasting-palate',
  templateUrl: './tasting-palate.page.html',
  styleUrls: ['./tasting-palate.page.scss'],
})
export class TastingPalatePage implements OnInit {
  stepper: TastingStepper;
  currentTab: string;

  constructor(private tastingsService: TastingsService, private router: Router) { }

  ngOnInit() {
    this.stepper = this.tastingsService.getStepper();
    this.currentTab = 'structure';
    if (!environment.production)
      console.log("TastingPalatePage ngOnInit: ", this.stepper);
      if (!this.stepper.tasting) this.router.navigate(['/tasting']);
  }

  setCurrentTab($event: Event) {
    if (!environment.production)
      console.log("TastingPalatePage setCurrentTab: ", $event);
    this.currentTab = ($event as SegmentCustomEvent).detail.value;
  }

  changeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate changeEvent: ", $event, this.stepper);
    this.stepper.tasting.palate.write();
  }
}
