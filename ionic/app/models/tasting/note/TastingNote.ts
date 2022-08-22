import { TastingSystemNote } from "src/app/interfaces/TastingSystemNote";

export class TastingNote {
    constructor(system: TastingSystemNote, public wineStyle: string) { }
}
