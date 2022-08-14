import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingPalatePrimary } from 'src/app/models/tasting/palate/TastingPalatePrimary';

@Component({
  selector: 'wj-tasting-palate-primary',
  templateUrl: './tasting-palate-primary.component.html',
})
export class TastingPalatePrimaryComponent implements OnInit {
  
  @Input() primary: TastingPalatePrimary;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingPalatePrimaryComponent ngOnInit: ", this.primary);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-primary isIncludedChangeEvent: ", $event, this.primary);
    this.primary.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.primary.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-primary propertyChangeEvent: ", $event, this.primary);
    this.primary.propertyChangeEvent($event);
    this.changeEvent.emit(this.primary.note);
  } 
}
