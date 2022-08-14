import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "../nose/TastingNoteWriter";

export class TastingPalateSecondaryNoteWriter extends TastingNoteWriter implements NoteWriter {
    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingPalateSecondaryNoteWriter write: ", set);

        var arr = new Array<string>();

        // Lees
        this.add(set, "lees ageing", arr, "Showing ", " from lees ageing.");

        // Malo
        this.add(set, "malo", arr, "Notes of ", " from malolactic fermentation.");

        // Oak
        this.add(set, "oak", arr, "Notes of ", " from oak ageing.");

        return arr.join(" ");
    }
}
