import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingNoseTertiaryNoteWriter } from "./TastingNoseTertiaryNoteWriter";
import { TastingNose } from "./TastingNose";

export class TastingNoseTertiary extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingNoseTertiaryNoteWriter());
        super.setProperties(system.properties);
    }
}
