import { TastingSystemProperty } from "./TastingSystemProperty"
import { TastingSystemAppearance } from "./TastingSystemAppearance"
import { TastingSystemNote } from "./TastingSystemNote"
import { TastingSystemSet } from "./TastingSystemSet"

export interface TastingSystem {
  style: TastingSystemProperty;
  primary: TastingSystemSet;
  secondary: TastingSystemSet;
  tertiary: TastingSystemSet;
  appearance: TastingSystemAppearance;
  nose: TastingSystemSet;
  palate: TastingSystemSet;
  conclusion: TastingSystemSet;
  note: TastingSystemNote;
}
