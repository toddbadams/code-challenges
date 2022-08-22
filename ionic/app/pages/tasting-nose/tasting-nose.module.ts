import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingNosePageRoutingModule } from './tasting-nose-routing.module';
import { TastingNosePage } from 'src/app/pages/tasting-nose/tasting-nose.page';
import { TastingPropertyModule } from 'src/app/components/tasting-property/tasting-property.module';
import { TastingNoseStructureComponent } from '../../components/tasting-nose-structure/tasting-nose-structure.component';
import { TastingNosePrimaryComponent } from 'src/app/components/tasting-nose-primary/tasting-nose-primary.component';
import { TastingNoseSecondaryComponent } from 'src/app/components/tasting-nose-secondary/tasting-nose-secondary.component';
import { TastingNoseTertiaryComponent } from 'src/app/components/tasting-nose-tertiary/tasting-nose-tertiary.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingNosePageRoutingModule,  
    TastingPropertyModule
  ],
  declarations: [TastingNosePage, TastingNoseStructureComponent, TastingNosePrimaryComponent, TastingNoseSecondaryComponent, TastingNoseTertiaryComponent]
})
export class TastingNosePageModule { }
