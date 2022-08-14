import { TastingSystemProperty } from "./TastingSystemProperty";
import { TastingSystemSet } from "./TastingSystemSet";

export interface TastingSystemAppearance extends TastingSystemSet {
  colors: Array<TastingSystemProperty>;
}



