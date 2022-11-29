import { TastingSystemStep } from "./TastingSystemStep";
import { TastingSystemProperty } from "./TastingSystemProperty"

export interface TastingSystem {
  steps: Array<TastingSystemStep>;
  properties: Array<TastingSystemProperty>;
}


