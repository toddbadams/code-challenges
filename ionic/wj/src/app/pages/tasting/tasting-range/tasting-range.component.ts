import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RangeCustomEvent } from '@ionic/angular';
import { RangeValue } from '@ionic/core';

@Component({
  selector: 'app-tasting-range',
  templateUrl: './tasting-range.component.html',
  styleUrls: ['./tasting-range.component.scss'],
})
export class TastingRangeComponent implements OnInit {
  level: string;
  label: string;

  @Input() range: string[] = null;
  @Input() title: string;

  @Output() newItemEvent = new EventEmitter<string>();

  ngOnInit() {
    this.label = this.range[0] + " " + this.title;
  }
  
  onIonChange(ev: Event) {
    this.level = this.range[(ev as RangeCustomEvent).detail.value as number];
    this.label = this.level + " " + this.title;
    this.newItemEvent.emit(this.level);
  }
}
