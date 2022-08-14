import { Component, OnInit } from '@angular/core';
import { TastingPropertyEvent } from 'src/app/models/tasting/property/TastingPropertyEvent';
import { TastingPropertyIsIncludedEvent } from 'src/app/models/tasting/property/TastingPropertyIsIncludedEvent';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'wj-tasting-appearance',
  templateUrl: './tasting-appearance.page.html',
  styleUrls: ['./tasting-appearance.page.scss'],
})
export class TastingAppearancePage implements OnInit {
  stepper: TastingStepper;

  constructor(private tastingsService: TastingsService, private router: Router) { }

  ngOnInit() {
    this.stepper = this.tastingsService.getStepper();
    if (!environment.production)
      console.log("wj-tasting-appearance ngOnInit: ", this.stepper);
    if (!this.stepper.tasting) this.router.navigate(['/tasting']);
    
    this.stepper.tasting.appearance.write();
  }

  isIncludedChangeEvent($event: TastingPropertyIsIncludedEvent) {
    if (!environment.production)
      console.log("wj-tasting-appearance isIncludedChangeEvent: ", $event, this.stepper);
    this.stepper.tasting.appearance.structure.isIncludedChangeEvent($event);
    this.stepper.tasting.appearance.write();
  }

  propertyChangeEvent($event: TastingPropertyEvent) {
    if (!environment.production)
      console.log("wj-tasting-appearance propertyChangeEvent: ", $event, this.stepper);
    this.stepper.tasting.appearance.structure.propertyChangeEvent($event);
    this.stepper.tasting.appearance.write();
  }
}
