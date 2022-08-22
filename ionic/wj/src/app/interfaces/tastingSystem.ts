import { TastingSystemProperty } from "./TastingSystemProperty"

export interface TastingSystem {
  style: Array<string>;
  steps: Array<TastingStep>;
  properties: Array<TastingSystemProperty>;
  // primary: TastingSystemSet;
  // secondary: TastingSystemSet;
  // tertiary: TastingSystemSet;
  // appearance: TastingSystemAppearance;
  // nose: TastingSystemSet;
  // palate: TastingSystemSet;
  // conclusion: TastingSystemSet;
  // note: TastingSystemNote;
}

export interface TastingStep {
  title: string;
  subtitle: string;
  properties: Array<string>;
}
