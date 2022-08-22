import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingNoseSecondaryNoteWriter } from "./TastingNoseSecondaryNoteWriter";
import { TastingNose } from "./TastingNose";

export class TastingNoseSecondary extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingNoseSecondaryNoteWriter());
        super.setProperties(system.properties);
    }
}
