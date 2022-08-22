import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "./TastingNoteWriter";


export class TastingNoseSecondaryNoteWriter extends TastingNoteWriter implements NoteWriter {
    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingNoseSecondaryNoteWriter write: ", set);

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
