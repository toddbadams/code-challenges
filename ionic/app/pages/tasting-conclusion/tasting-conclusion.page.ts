import { Component, OnInit } from '@angular/core';
import { TastingPropertyEvent } from 'src/app/models/tasting/property/TastingPropertyEvent';
import { TastingPropertyIsIncludedEvent } from 'src/app/models/tasting/property/TastingPropertyIsIncludedEvent';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'wj-tasting-conclusion',
  templateUrl: './tasting-conclusion.page.html',
  styleUrls: ['./tasting-conclusion.page.scss'],
})
export class TastingConclusionPage implements OnInit {
  stepper: TastingStepper;

  constructor(private tastingsService: TastingsService, private router: Router) { }

  ngOnInit() {
    this.stepper = this.tastingsService.getStepper();
    if (!environment.production)
      console.log("wj-tasting-conclusion ngOnInit: ", this.stepper);
      if (!this.stepper.tasting) this.router.navigate(['/tasting']);
  }

  isIncludedChangeEvent($event: TastingPropertyIsIncludedEvent) {
    if (!environment.production)
      console.log("wj-tasting-conclusion isIncludedChangeEvent: ", $event, this.stepper);
    this.stepper.tasting.conclusion.structure.isIncludedChangeEvent($event);
  }

  propertyChangeEvent($event: TastingPropertyEvent) {
    if (!environment.production)
      console.log("wj-tasting-conclusion propertyChangeEvent: ", $event, this.stepper);
    this.stepper.tasting.conclusion.structure.propertyChangeEvent($event);
  }
}
