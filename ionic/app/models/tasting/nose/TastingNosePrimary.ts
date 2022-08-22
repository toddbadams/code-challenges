import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingNosePrimaryNoteWriter } from "./TastingNosePrimaryNoteWriter";
import { TastingNose } from "./TastingNose";


export class TastingNosePrimary extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingNosePrimaryNoteWriter());
        super.setProperties(system.properties);
    }
}
