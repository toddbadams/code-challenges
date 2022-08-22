import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { TastingConclusionPage } from './tasting-conclusion.page';

describe('TastingConclusionComponent', () => {
  let component: TastingConclusionPage;
  let fixture: ComponentFixture<TastingConclusionPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TastingConclusionPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(TastingConclusionPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
