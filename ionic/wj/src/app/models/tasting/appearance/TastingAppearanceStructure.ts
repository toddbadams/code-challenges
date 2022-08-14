import { TastingSystemAppearance } from "src/app/interfaces/TastingSystemAppearance";
import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { TastingAppearanceNoteWriter } from "./TastingAppearanceNoteWriter";

export class TastingAppearanceStructure extends TastingPropertySet {
    constructor(system: TastingSystemAppearance, wineStyle: string) {
        super(system.title, wineStyle, new TastingAppearanceNoteWriter());
        system.properties.push(system.colors.find(c => c.title == wineStyle));
        super.setProperties(system.properties);
    }
}
