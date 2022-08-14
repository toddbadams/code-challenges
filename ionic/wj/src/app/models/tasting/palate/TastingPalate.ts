import { TastingPalateTertiary } from "./TastingPalateTertiary";
import { TastingPalateSecondary } from "./TastingPalateSecondary";
import { TastingPalatePrimary } from "./TastingPalatePrimary";
import { TastingSystem } from "src/app/interfaces/tastingSystem";
import { TastingPalateStructure } from "./TastingPalateStructure";
import { environment } from "src/environments/environment";



export class TastingPalate {
    structure: TastingPalateStructure;
    primary: TastingPalatePrimary;
    secondary: TastingPalateSecondary;
    tertiary: TastingPalateTertiary;
    note: string;

    constructor(system: TastingSystem, style: string) {
        this.structure = new TastingPalateStructure(system.palate, style);
        this.primary = new TastingPalatePrimary(system.primary, style);
        this.secondary = new TastingPalateSecondary(system.secondary, style);
        this.tertiary = new TastingPalateTertiary(system.tertiary, style);
    }
    write(): void {
        this.note = this.structure.note + (this.structure.note.length > 0 ? " " : "") +
            this.primary.note + (this.primary.note.length > 0 ? " " : "") +
            this.secondary.note + (this.secondary.note.length > 0 ? " " : "") +
            this.tertiary.note;
        if (!environment.production)
            console.log("TastingPalate write: ", this);
    }
}
