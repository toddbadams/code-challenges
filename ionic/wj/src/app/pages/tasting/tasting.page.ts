import { Component, OnInit } from '@angular/core';
import { Tasting } from "src/app/models/tasting/Tasting";
import { TastingsService } from 'src/app/services/tastings/tastings.service';

@Component({
  selector: 'app-tasting',
  templateUrl: './tasting.page.html',
  styleUrls: ['./tasting.page.scss'],
})
export class TastingPage implements OnInit {

  systemId: string = "wset4";
  tasting: Tasting;

  constructor(private tastingsService: TastingsService) { }

  ngOnInit() {
    this.tastingsService.getTastingSystem(this.systemId).subscribe(x => {
      this.tasting = new Tasting(x);
      console.log(this.tasting);
    });
  }
}
