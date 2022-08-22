import { Component, OnInit } from '@angular/core';
import { Tasting } from 'src/app/models/tasting/Tasting';
import { TastingsGroup } from 'src/app/models/tasting/TastingsGroup';
import { TastingsService } from 'src/app/services/tastings/tastings.service';

@Component({
  selector: 'wj-tastings',
  templateUrl: './tastings.page.html',
  styleUrls: ['./tastings.page.scss'],
})
export class TastingsPage implements OnInit {
  tastings: Tasting[];
  groups: TastingsGroup[];
  groupBy: string;

  constructor(private tastingsService: TastingsService) {
  }

  ngOnInit() {
    this.tastingsService
      .getTastings()
      .subscribe(x => {
        this.tastings = x;
        this.groupByProducer();
      });
  }

  groupByVariety() {
    const x = this.tastings.reduce((group, item) => {
      const { variety } = item;
      group[variety] = group[variety] ?? [];
      group[variety].push(item);
      return group;
    }, {});
    this.setGroup(x,'variety');
  }

  groupByProducer() {
    const x = this.tastings.reduce((group, item) => {
      const { producer } = item;
      group[producer] = group[producer] ?? [];
      group[producer].push(item);
      return group;
    }, {});
    this.setGroup(x,'producer');
  }

  groupByRegion() {
    const x = this.tastings.reduce((group, item) => {
      const { region } = item;
      group[region] = group[region] ?? [];
      group[region].push(item);
      return group;
    }, {});
    this.setGroup(x,'region');
  }

  setGroup(x: any, name: string) {    
    const keys = Object.keys(x);
    const values = Object.values(x);
    const l = keys.length;
    this.groups = new Array<TastingsGroup>(l);
    for (var i = 0; i < l; i++) {
      this.groups[i] = new TastingsGroup(keys[i], values[i] as Tasting[]);
    }
    this.groupBy = name;
  }
}
