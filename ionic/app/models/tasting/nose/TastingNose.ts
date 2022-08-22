import { TastingNoseTertiary } from "./TastingNoseTertiary";
import { TastingNoseSecondary } from "./TastingNoseSecondary";
import { TastingNosePrimary } from "./TastingNosePrimary";
import { TastingSystem } from "src/app/interfaces/tastingSystem";
import { TastingNoseStructure } from "./TastingNoseStructure";
import { environment } from "src/environments/environment";


export class TastingNose {
    structure: TastingNoseStructure;
    primary: TastingNosePrimary;
    secondary: TastingNoseSecondary;
    tertiary: TastingNoseTertiary;
    note: string;

    constructor(system: TastingSystem, style: string) {
        this.structure = new TastingNoseStructure(system.nose, style);
        this.primary = new TastingNosePrimary(system.primary, style);
        this.secondary = new TastingNoseSecondary(system.secondary, style);
        this.tertiary = new TastingNoseTertiary(system.tertiary, style);
    }

    write(): void {
        this.note = this.structure.note + (this.structure.note.length > 0 ? " " : "") +
            this.primary.note + (this.primary.note.length > 0 ? " " : "") +
            this.secondary.note + (this.secondary.note.length > 0 ? " " : "") +
            this.tertiary.note;
        if (!environment.production)
            console.log("TastingNose write: ", this);
    }
}
