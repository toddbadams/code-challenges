import { TastingSystem } from "src/app/interfaces/TastingSystem";
import { TastingAppearanceStructure } from "./appearance/TastingAppearanceStructure";
import { TastingNoseTertiary } from "./nose/TastingNoseTertiary";
import { TastingNoseSecondary } from "./nose/TastingNoseSecondary";
import { TastingNoseStructure } from "./nose/TastingNoseStructure";
import { TastingNosePrimary } from "./nose/TastingNosePrimary";
import { TastingConclusionStructure } from "./conclusion/TastingConclusionStructure";
import { TastingNose } from "./nose/TastingNose";
import { TastingPalate } from "./palate/TastingPalate";
import { TastingConclusion } from "./conclusion/TastingConclusion";
import { TastingAppearance } from "./appearance/TastingAppearance";

export class Tasting {
    appearance: TastingAppearance;
    nose: TastingNose;
    palate: TastingPalate;
    conclusion: TastingConclusion;
    note: string;
    featured_image: string;
    seo_title: string;
    published: Date;
    gps: string;
    producer: string;
    vintage: number;
    region: string;
    variety: string;
    summary: string;

    constructor(public style: string, system: TastingSystem) {
        this.appearance = new TastingAppearance(system, style);
        this.nose = new TastingNose(system, style);
        this.palate = new TastingPalate(system, style);
        this.conclusion = new TastingConclusion(system, style);
        this.note = "";
    }
}

