import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "./TastingNoteWriter";

export class TastingNoseNoteStructureWriter extends TastingNoteWriter implements NoteWriter {
    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingNoseNoteStructureWriter write: ", set);

        var arr = new Array<string>();

        // Faults
        this.add(set, "faults", arr, "The wine shows ", " faults.");
        if (arr.length === 1) return arr[0];

        // intensity
        this.add(set, "intensity", arr, "The wine has a ", " intensity on the nose.");
        return (arr.length === 1)  ? arr[0] : "";
    }
}

