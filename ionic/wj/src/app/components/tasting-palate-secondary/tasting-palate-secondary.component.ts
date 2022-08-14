import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingPalateSecondary } from 'src/app/models/tasting/palate/TastingPalateSecondary';

@Component({
  selector: 'wj-tasting-palate-secondary',
  templateUrl: './tasting-palate-secondary.component.html',
})
export class TastingPalateSecondaryComponent implements OnInit {
  
  @Input() secondary: TastingPalateSecondary;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingPalateSecondaryComponent ngOnInit: ", this.secondary);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-secondary isIncludedChangeEvent: ", $event, this.secondary);
    this.secondary.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.secondary.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-secondary propertyChangeEvent: ", $event, this.secondary);
    this.secondary.propertyChangeEvent($event);
    this.changeEvent.emit(this.secondary.note);
  } 
}
