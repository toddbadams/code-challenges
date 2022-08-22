import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingAppearancePageRoutingModule} from './tasting-appearance-routing.module';
import { TastingAppearancePage } from 'src/app/pages/tasting-appearance/tasting-appearance.page';
import { TastingPropertyModule } from 'src/app/components/tasting-property/tasting-property.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingAppearancePageRoutingModule,  
    TastingPropertyModule
  ],
  declarations: [TastingAppearancePage]
})
export class TastingAppearancePageModule {}
