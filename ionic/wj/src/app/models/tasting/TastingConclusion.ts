import { TastingSystemConclusion } from "src/app/interfaces/TastingSystemConclusion";


export class TastingConclusion {
    isVisible: boolean;
    quality: string;
    aging: string;

    constructor(public system: TastingSystemConclusion) {
    }
}
