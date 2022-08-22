import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TastingPropertyDisplayEnum } from 'src/app/interfaces/TastingPropertyDisplayEnum';
import { TastingPropertyEvent } from 'src/app/models/tasting/property/TastingPropertyEvent';
import { TastingPropertyIsIncludedEvent } from 'src/app/models/tasting/property/TastingPropertyIsIncludedEvent';
import { TastingProperty } from 'src/app/models/tasting/property/TastingPropery';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'wj-tasting-property',
  templateUrl: './tasting-property.component.html',
  styleUrls: ['./tasting-property.component.scss'],
})
export class TastingPropertyComponent implements OnInit {

  @Input() property: TastingProperty;
  @Output() propertyChangeEvent = new EventEmitter<TastingPropertyEvent>();
  @Output() isIncludedChangeEvent = new EventEmitter<TastingPropertyIsIncludedEvent>();

  ngOnInit(): void {
    if (this.property === undefined || this.property === null) throw new Error('wj-tasting-property: property not defined');
    if (!environment.production) console.log("wj-tasting-property ngOnInit: ", this.property);
  }

  onPropertyChange($event: Event) {
    if (!environment.production) console.log("wj-tasting-property onChange: ", $event);

    if (this.property.isMultiSelect) {
      this.propertyChangeEvent.emit(new TastingPropertyEvent(this.property.title, null, ($event as CustomEvent).detail.value as string[]));
      return;
    } 
    if (this.property.display == TastingPropertyDisplayEnum.select) {
      this.propertyChangeEvent.emit(new TastingPropertyEvent(this.property.title, ($event as CustomEvent).detail.value as string, null));
      return;
    }
    if (this.property.display == TastingPropertyDisplayEnum.range) {
      var i = ($event as CustomEvent).detail.value as number;
      var value = this.property.values[i];
      this.propertyChangeEvent.emit(new TastingPropertyEvent(this.property.title, value, null));
      return;
    }
  }

  onIsIncludedChange($event: Event) {
    if (!environment.production) console.log("wj-tasting-property onIsIncludedChange: ", $event);
    this.isIncludedChangeEvent.emit(new TastingPropertyIsIncludedEvent(this.property.title, ($event as CustomEvent).detail.checked as boolean));
  }

  isSelectDisplay() {
    return this.property.isIncluded && this.property.display == TastingPropertyDisplayEnum.select;
  }

  isRangeDisplay() {
    return this.property.isIncluded && this.property.display == TastingPropertyDisplayEnum.range;
  }

  getValue() {
    if(this.property.isMultiSelect) return this.property.selectedValues;
    return this.property.selectedValue;
  }
}
