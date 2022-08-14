import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingPalatePrimaryNoteWriter } from "./TastingPalatePrimaryNoteWriter";
import { TastingPalate } from "./TastingPalate";

export class TastingPalatePrimary extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingPalatePrimaryNoteWriter());
        super.setProperties(system.properties);
    }
}
