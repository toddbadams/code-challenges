import { TastingSystem } from "src/app/interfaces/TastingSystem";
import { environment } from "src/environments/environment";
import { TastingAppearanceStructure } from "./TastingAppearanceStructure";

export class TastingAppearance {
    structure: TastingAppearanceStructure;
    note: string;

    constructor(system: TastingSystem, style: string) {
        this.structure = new TastingAppearanceStructure(system.appearance, style);
    }

    write(): void {
        this.note = this.structure.note;
        if (!environment.production)
            console.log("TastingAppearance write: ", this);
    }
}

