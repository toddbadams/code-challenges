import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingPalateTertiaryNoteWriter } from "./TastingPalateTertiaryNoteWriter";

export class TastingPalateTertiary extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingPalateTertiaryNoteWriter());
        super.setProperties(system.properties);
    }
}
