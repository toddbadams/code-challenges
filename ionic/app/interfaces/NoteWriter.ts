import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";

export interface NoteWriter {
    write(tastingPropertySet: TastingPropertySet): string;
}

