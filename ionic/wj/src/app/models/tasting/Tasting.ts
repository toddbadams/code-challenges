import { TastingSystem } from "src/app/interfaces/tastingSystem";
import { TastingAppearance } from "./TastingAppearance";
import { TastingNose } from "./TastingNose";


export class Tasting {
    id: string;
    name: string;
    appearance: TastingAppearance;
    nose: TastingNose;

    constructor(tastingSystem: TastingSystem) {
        this.name = "New Tasting";
        this.appearance = new TastingAppearance(tastingSystem.appearance);
        this.nose = new TastingNose(tastingSystem.nose);
    }
}
