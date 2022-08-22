import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'wj-tasting-note',
  templateUrl: './tasting-note.page.html',
  styleUrls: ['./tasting-note.page.scss'],
})
export class TastingNotePage  implements OnInit {
  stepper: TastingStepper;
  
  constructor(private tastingsService: TastingsService, private router: Router) { }

  ngOnInit() {
    this.stepper = this.tastingsService.getStepper();
    if (!environment.production)
      console.log("wj-tasting-note ngOnInit: ", this.stepper);
    if (!this.stepper.tasting) this.router.navigate(['/tasting']);
  }
}
