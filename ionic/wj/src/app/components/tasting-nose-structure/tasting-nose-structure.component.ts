import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TastingNoseStructure } from 'src/app/models/tasting/nose/TastingNoseStructure';

@Component({
  selector: 'wj-tasting-nose-structure',
  templateUrl: './tasting-nose-structure.component.html',
})
export class TastingNoseStructureComponent implements OnInit {
  
  @Input() structure: TastingNoseStructure;
  @Output() changeEvent = new EventEmitter<string>();
  
  constructor() { }

  ngOnInit() {
    if (!environment.production)
      console.log("TastingNoseStructureComponent ngOnInit: ", this.structure);
  }

  isIncludedChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-structure isIncludedChangeEvent: ", $event, this.structure);
    this.structure.isIncludedChangeEvent($event);
    this.changeEvent.emit(this.structure.note);
  }

  propertyChangeEvent($event: any) {
    if (!environment.production)
      console.log("wj-tasting-nose-structure propertyChangeEvent: ", $event, this.structure);
    this.structure.propertyChangeEvent($event);
    this.changeEvent.emit(this.structure.note);
  } 
}
