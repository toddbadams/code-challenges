import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { RegionTypeaheadComponent } from './region-typeahead.component';

describe('RegionTypeaheadComponent', () => {
  let component: RegionTypeaheadComponent;
  let fixture: ComponentFixture<RegionTypeaheadComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ RegionTypeaheadComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(RegionTypeaheadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
