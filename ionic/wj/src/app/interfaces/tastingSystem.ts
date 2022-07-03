import { TastingSystemAppearance } from "./TastingSystemAppearance"
import { TastingSystemConclusion } from "./TastingSystemConclusion"
import { TastingSystemNose } from "./TastingSystemNose"
import { TastingSystemNote } from "./TastingSystemNote"
import { TastingSystemPalate } from "./TastingSystemPalate"

export interface TastingSystem {
    appearance: TastingSystemAppearance
    nose: TastingSystemNose
    palate: TastingSystemPalate
    conclusion: TastingSystemConclusion
    note: TastingSystemNote
  }
  
