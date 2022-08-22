import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TastingNoseSecondaryComponent } from './tasting-nose-secondary.component';

describe('TastingNoseComponent', () => {
  let component: TastingNoseSecondaryComponent;
  let fixture: ComponentFixture<TastingNoseSecondaryComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TastingNoseSecondaryComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TastingNoseSecondaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
