import { Component, Input, OnInit } from '@angular/core';
import { RangeCustomEvent } from '@ionic/angular';
import { TastingNose } from 'src/app/models/tasting/TastingNose';

@Component({
  selector: 'app-tasting-nose',
  templateUrl: './tasting-nose.component.html',
  styleUrls: ['./tasting-nose.component.scss'],
})
export class TastingNoseComponent implements OnInit {

  @Input()
    nose: TastingNose;
    
  constructor() { }

  ngOnInit() {}

  setIntensity(ev: Event) {
    this.nose.intensity = this.nose.system.intensities[(ev as RangeCustomEvent).detail.value as number];    
    this.nose.writeNote();
  }

  setRipeness(ev: Event) {
    this.nose.ripeness = this.nose.system.ripeness[(ev as RangeCustomEvent).detail.value as number];    
    this.nose.writeNote();
  }

  setGreenFruit(ev: Event){
    this.nose.greenFruit = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setCitrusFruit(ev: Event){
    this.nose.citrusFruit = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setStoneFruit(ev: Event){
    this.nose.stoneFruit = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setTropicalFruit(ev: Event){
    this.nose.tropicalFruit = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setRedFruit(ev: Event){
    this.nose.redFruit = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setBlackFruit(ev: Event){
    this.nose.blackFruit = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setFloral(ev: Event){
    this.nose.floral = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setHerbaceous(ev: Event){
    this.nose.herbaceous = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setHerbal(ev: Event){
    this.nose.herbal = (ev as CustomEvent).detail.value  as string[];
    this.nose.writeNote();
  }

  setSpice(ev: Event){
    this.nose.spice = (ev as CustomEvent).detail.value as string[];
    this.nose.writeNote();
  }

}
