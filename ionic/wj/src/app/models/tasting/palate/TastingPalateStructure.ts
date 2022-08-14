import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingPalateStructureNoteWriter } from "./TastingPalateStructureNoteWriter";
import { TastingPalate } from "./TastingPalate";


export class TastingPalateStructure extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingPalateStructureNoteWriter());
        super.setProperties(system.properties);
    }
}
