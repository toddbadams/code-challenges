import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'wj-tasting-details',
  templateUrl: './tasting-details.page.html',
  styleUrls: ['./tasting-details.page.scss'],
})
export class TastingDetailsPage  implements OnInit {
  stepper: TastingStepper;
  
  constructor(private tastingsService: TastingsService, private router: Router) { }

  ngOnInit() {
      this.stepper = this.tastingsService.getStepper();
      if (!environment.production)
        console.log("wj-tasting-details ngOnInit: ", this.stepper);
      if (!this.stepper.tasting) this.router.navigate(['/tasting']);
  }
}
