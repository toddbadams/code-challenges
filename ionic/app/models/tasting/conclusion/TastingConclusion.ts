import { TastingSystem } from "src/app/interfaces/tastingSystem";
import { environment } from "src/environments/environment";
import { TastingConclusionStructure } from "./TastingConclusionStructure";

export class TastingConclusion {
    structure: TastingConclusionStructure;
    note: string;

    constructor(system: TastingSystem, style: string) {
        this.structure = new TastingConclusionStructure(system.conclusion, style);
    }

    write(): void {
        this.note = this.structure.note;
        if (!environment.production)
            console.log("TastingConclusion write: ", this);
    }
}
