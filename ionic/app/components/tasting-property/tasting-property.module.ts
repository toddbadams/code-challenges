import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingPropertyComponent } from 'src/app/components/tasting-property/tasting-property.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule
  ],
  declarations: [TastingPropertyComponent],
  exports: [TastingPropertyComponent]
})
export class TastingPropertyModule {}
