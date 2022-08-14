import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingPalateSecondaryNoteWriter } from "./TastingPalateSecondaryNoteWriter";

export class TastingPalateSecondary extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingPalateSecondaryNoteWriter());
        super.setProperties(system.properties);
    }
}
