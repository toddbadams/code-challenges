import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingStepperPageRoutingModule } from './tasting-stepper-routing.module';
import { TastingStepperPage } from './tasting-stepper.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingStepperPageRoutingModule
  ],
  declarations: [TastingStepperPage]
})
export class TastingStepperPageModule {}
