import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AnimationController, RangeCustomEvent } from '@ionic/angular';
import { TastingsService } from 'src/app/services/tastings/tastings.service';

@Component({
  selector: 'wj-region-typeahead',
  templateUrl: './region-typeahead.component.html',
  styleUrls: ['./region-typeahead.component.scss'],
})
export class RegionTypeaheadComponent implements OnInit {
  regions: string[];
  searching = false;
  inputfired = false;
  filterTerm: string;

  @Input() region: string;

  @ViewChild('headerwrapper', { read: ElementRef }) headerWrapper: ElementRef
  @ViewChild('condenseheader', { read: ElementRef }) condenseheader: ElementRef
  @ViewChild('overlay') overlay: ElementRef

  constructor(private tastingsService: TastingsService,
    private animationCtrl: AnimationController) { }

  ngOnInit() {
    this.tastingsService.getRegions().subscribe(x => {
      this.regions = x;
    });
  }

  toggleSearch() {
    if (this.inputfired) return;
    this.inputfired = true;
    const titleToolbar = this.condenseheader.nativeElement.children[0];
    const toolbarFade = this.animationCtrl.create('fade')
      .addElement(this.headerWrapper.nativeElement)
      .fromTo('opacity', 1, 0)
      .fromTo('height', '90px', '36px')
      .afterStyles({ 'z-index': -1 });

    const headerFade = this.animationCtrl.create('header')
      .addElement(titleToolbar)
      .fromTo('opacity', 1, 0)
      .fromTo('height', '48px', '0px')
      .afterStyles({ 'z-index': -1 });

    const wrapper = this.animationCtrl.create('wrapper')
      .addAnimation([toolbarFade, headerFade])
      .easing('ease-in')
      .duration(200);

    const overlayFade = this.animationCtrl.create('overlay')
      .addElement(this.overlay.nativeElement)
      .fromTo('opacity', 0, 0.1)
      .duration(200);

    if (this.searching) {
      wrapper.direction('reverse').play()
      overlayFade.direction('reverse').beforeStyles({ 'z-index': 0 }).play()
    } else {
      wrapper.play();
      overlayFade.beforeStyles({ 'z-index': 2 }).play()
    }

    this.inputfired = false;
    this.searching = !this.searching;
  }

  ionChange(ev: Event) {
    console.log(ev);
  }

  
  itemClick(region: string) {
    console.log(region);
  }
}
