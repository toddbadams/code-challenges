import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TastingPalatePageRoutingModule } from './tasting-palate-routing.module';
import { TastingPalatePage } from 'src/app/pages/tasting-palate/tasting-palate.page';
import { TastingPropertyModule } from 'src/app/components/tasting-property/tasting-property.module';
import { TastingPalatePrimaryComponent } from 'src/app/components/tasting-palate-primary/tasting-palate-primary.component';
import { TastingPalateSecondaryComponent } from 'src/app/components/tasting-palate-secondary/tasting-palate-secondary.component';
import { TastingPalateTertiaryComponent } from 'src/app/components/tasting-palate-tertiary/tasting-palate-tertiary.component';
import { TastingPalateStructureComponent } from 'src/app/components/tasting-palate-structure/tasting-palate-structure.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TastingPalatePageRoutingModule,  
    TastingPropertyModule
  ],
  declarations: [TastingPalatePage, TastingPalateStructureComponent, TastingPalatePrimaryComponent, TastingPalateSecondaryComponent, TastingPalateTertiaryComponent]
})
export class TastingPalatePageModule {}
