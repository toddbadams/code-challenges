import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "../nose/TastingNoteWriter";

export class TastingPalateTertiaryNoteWriter extends TastingNoteWriter implements NoteWriter {
    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingPalateTertiaryNoteWriter write: ", set);
        var arr = new Array<string>();

        // Dried Fruit
        this.add(set, "dried fruits", arr, "Notes of ", " dried fruits.");

        // Earth
        this.add(set, "earth", arr, "Notes of ", ".");
        // Red
        this.add(set, "general red", arr, "Notes of ", ".");
        // White
        this.add(set, "general white", arr, "Notes of ", ".");

        // Oak
        this.add(set, "oxidisation", arr, "Notes of ", " from oxidisation.");

        return arr.join(" ");
    }
}
