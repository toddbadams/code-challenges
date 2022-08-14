import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingStylePageRoutingModule} from './tasting-style-routing.module';
import { TastingStylePage } from './tasting-style.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingStylePageRoutingModule
  ],
  declarations: [TastingStylePage]
})
export class TastingStylePageModule {}
