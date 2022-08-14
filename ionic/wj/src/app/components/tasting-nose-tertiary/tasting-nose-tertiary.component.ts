import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingNoseTertiary } from 'src/app/models/tasting/nose/TastingNoseTertiary';

@Component({
  selector: 'wj-tasting-nose-tertiary',
  templateUrl: './tasting-nose-tertiary.component.html',
})
export class TastingNoseTertiaryComponent implements OnInit {
  
  @Input() tertiary: TastingNoseTertiary;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingNoseTertiaryComponent ngOnInit: ", this.tertiary);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-tertiary isIncludedChangeEvent: ", $event, this.tertiary);
    this.tertiary.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.tertiary.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-tertiary propertyChangeEvent: ", $event, this.tertiary);
    this.tertiary.propertyChangeEvent($event);
    this.changeEvent.emit(this.tertiary.note);
  } 
}
