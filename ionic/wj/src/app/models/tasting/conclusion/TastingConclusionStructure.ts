import { TastingSystemSet } from "src/app/interfaces/TastingSystemSet";
import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingConclusionNoteWriter } from "./TastingConclusionNoteWriter";
import { TastingConclusion } from "./TastingConclusion";


export class TastingConclusionStructure extends TastingPropertySet {
    constructor(system: TastingSystemSet, wineStyle: string) {
        super(system.title, wineStyle, new TastingConclusionNoteWriter());
        super.setProperties(system.properties);
    }
}
