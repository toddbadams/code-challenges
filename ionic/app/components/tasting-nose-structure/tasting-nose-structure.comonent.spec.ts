import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TastingNoseStructureComponent } from './tasting-nose-structure.component';

describe('TastingNoseComponent', () => {
  let component: TastingNoseStructureComponent;
  let fixture: ComponentFixture<TastingNoseStructureComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TastingNoseStructureComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TastingNoseStructureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
