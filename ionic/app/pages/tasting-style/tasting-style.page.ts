import { Component } from '@angular/core';
import { TastingsService } from 'src/app/services/tastings/tastings.service';
import { Router } from '@angular/router';

@Component({
  selector: 'wj-tasting-style',
  templateUrl: './tasting-style.page.html',
  styleUrls: ['./tasting-style.page.scss'],
})
export class TastingStylePage {

  constructor(private tastingService: TastingsService, private router: Router){}
  setStyle(style: string){
    this.tastingService.stepper.selectStyle(style);
    this.router.navigate(['/tasting/appearance'])
  }
}
