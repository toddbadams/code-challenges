import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "../nose/TastingNoteWriter";

export class TastingPalateStructureNoteWriter extends TastingNoteWriter implements NoteWriter {
    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingPalateStructureNoteWriter write: ", set);

            var arr = new Array<string>();


    
            return arr.join(" ");
    }
}
