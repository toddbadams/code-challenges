import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingConclusionPageRoutingModule } from './tasting-conclusion-routing.module';
import { TastingConclusionPage } from 'src/app/pages/tasting-conclusion/tasting-conclusion.page';
import { TastingPropertyModule } from 'src/app/components/tasting-property/tasting-property.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingConclusionPageRoutingModule,  
    TastingPropertyModule
  ],
  declarations: [TastingConclusionPage]
})
export class TastingConclusionPageModule {}
