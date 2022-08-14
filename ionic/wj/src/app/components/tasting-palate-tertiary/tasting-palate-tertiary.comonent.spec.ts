import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TastingPalateTertiaryComponent } from './tasting-palate-tertiary.component';

describe('TastingPalateComponent', () => {
  let component: TastingPalateTertiaryComponent;
  let fixture: ComponentFixture<TastingPalateTertiaryComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TastingPalateTertiaryComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TastingPalateTertiaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
