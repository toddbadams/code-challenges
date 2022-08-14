import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingNosePrimary } from 'src/app/models/tasting/nose/TastingNosePrimary';

@Component({
  selector: 'wj-tasting-nose-primary',
  templateUrl: './tasting-nose-primary.component.html',
})
export class TastingNosePrimaryComponent implements OnInit {
  
  @Input() primary: TastingNosePrimary;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingNosePrimaryComponent ngOnInit: ", this.primary);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-primary isIncludedChangeEvent: ", $event, this.primary);
    this.primary.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.primary.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-primary propertyChangeEvent: ", $event, this.primary);
    this.primary.propertyChangeEvent($event);
    this.changeEvent.emit(this.primary.note);
  } 
}
