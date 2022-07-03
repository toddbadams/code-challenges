import { TastingSystemPalate } from "src/app/interfaces/TastingSystemPalate";



export class TastingPalate {
    isVisible: boolean;
    intensity: string;
    flavors: string[];
    ripeness: string;
    acidity: string;
    sweetness: string;
    tannins: string;
    alcohol: string;
    body: string;
    texture: string;
    petillance: string;
    balance: string;
    length: string;
    complexity: string;

    constructor(public system: TastingSystemPalate) {
    }
}
