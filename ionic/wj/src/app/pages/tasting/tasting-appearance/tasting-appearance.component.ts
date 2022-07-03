import { Component, Input } from '@angular/core';
import { RangeCustomEvent } from '@ionic/angular';
import { TastingAppearance } from 'src/app/models/tasting/TastingAppearance';

@Component({
  selector: 'app-tasting-appearance',
  templateUrl: './tasting-appearance.component.html',
  styleUrls: ['./tasting-appearance.component.scss'],
})
export class TastingAppearanceComponent {

  @Input() appearance: TastingAppearance;

  writeNote(){
    this.appearance.writeNote();
  }

  setBrightness(x:string) {
    this.appearance.brightness = x;
    this.appearance.writeNote();
  }

  setClarity(x:string) {
    this.appearance.clarity = x;
    this.appearance.writeNote();
  }

  setIntensity(ev: Event) {
    this.appearance.intensity = this.appearance.system.intensities[(ev as RangeCustomEvent).detail.value as number];    
    this.appearance.writeNote();
  }

  setColor(x:string) {
    this.appearance.color = x;
    this.appearance.writeNote();
  }
}
