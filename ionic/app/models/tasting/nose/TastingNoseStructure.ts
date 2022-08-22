import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingNoseNoteStructureWriter } from "./TastingNoseNoteStructureWriter";
import { TastingNose } from "./TastingNose";


export class TastingNoseStructure extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingNoseNoteStructureWriter());
        super.setProperties(system.properties);
    }
}


