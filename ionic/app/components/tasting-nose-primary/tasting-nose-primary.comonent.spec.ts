import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TastingNosePrimaryComponent } from './tasting-nose-primary.component';

describe('TastingNoseComponent', () => {
  let component: TastingNosePrimaryComponent;
  let fixture: ComponentFixture<TastingNosePrimaryComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TastingNosePrimaryComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TastingNosePrimaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
