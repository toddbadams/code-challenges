import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";

export class TastingConclusionNoteWriter implements NoteWriter {

    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingConclusionNoteWriter write: ", set);

        return "";
    }
}
