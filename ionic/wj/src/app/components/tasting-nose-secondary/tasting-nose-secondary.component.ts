import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingNoseSecondary } from 'src/app/models/tasting/nose/TastingNoseSecondary';

@Component({
  selector: 'wj-tasting-nose-secondary',
  templateUrl: './tasting-nose-secondary.component.html',
})
export class TastingNoseSecondaryComponent implements OnInit {
  
  @Input() secondary: TastingNoseSecondary;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingNoseSecondaryComponent ngOnInit: ", this.secondary);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-secondary isIncludedChangeEvent: ", $event, this.secondary);
    this.secondary.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.secondary.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-secondary propertyChangeEvent: ", $event, this.secondary);
    this.secondary.propertyChangeEvent($event);
    this.changeEvent.emit(this.secondary.note);
  } 
}
