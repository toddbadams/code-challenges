import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingPalateStructure } from 'src/app/models/tasting/palate/TastingPalateStructure';

@Component({
  selector: 'wj-tasting-palate-structure',
  templateUrl: './tasting-palate-structure.component.html',
})
export class TastingPalateStructureComponent implements OnInit {
  
  @Input() structure: TastingPalateStructure;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingPalateStructureComponent ngOnInit: ", this.structure);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-structure isIncludedChangeEvent: ", $event, this.structure);
    this.structure.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.structure.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-palate-structure propertyChangeEvent: ", $event, this.structure);
    this.structure.propertyChangeEvent($event);
    this.changeEvent.emit(this.structure.note);
  } 
}
