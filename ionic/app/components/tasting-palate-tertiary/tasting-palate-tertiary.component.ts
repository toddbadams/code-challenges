import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingPalateTertiary } from 'src/app/models/tasting/palate/TastingPalateTertiary';

@Component({
  selector: 'wj-tasting-palate-tertiary',
  templateUrl: './tasting-palate-tertiary.component.html',
})
export class TastingPalateTertiaryComponent implements OnInit {
  
  @Input() tertiary: TastingPalateTertiary;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingPalateTertiaryComponent ngOnInit: ", this.tertiary);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-tertiary isIncludedChangeEvent: ", $event, this.tertiary);
    this.tertiary.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.tertiary.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-tertiary propertyChangeEvent: ", $event, this.tertiary);
    this.tertiary.propertyChangeEvent($event);
    this.changeEvent.emit(this.tertiary.note);
  } 
}
