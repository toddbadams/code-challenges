import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TastingPalatePage } from './tasting-palate.page';

describe('TastingPalateComponent', () => {
  let component: TastingPalatePage;
  let fixture: ComponentFixture<TastingPalatePage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TastingPalatePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TastingPalatePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
