import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "../nose/TastingNoteWriter";

export class TastingPalatePrimaryNoteWriter extends TastingNoteWriter implements NoteWriter {
    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingPalatePrimaryNoteWriter write: ", set);
            var arr = new Array<string>();

            // Floral notes
            this.add(set, "floral notes", arr, "Floral notes of ", ".");
    
            // Fruit notes
            var fruitArr = new Array<string>();
            this.add(set, "green fruits", fruitArr);
            this.add(set, "citrus fruits", fruitArr);
            this.add(set, "stone fruits", fruitArr);
            this.add(set, "tropical fruits", fruitArr);
            this.add(set, "red fruits", fruitArr);
            this.add(set, "black fruits", fruitArr);
            var ripeness = set.getProperty("ripeness").text();
            var dominate = set.getProperty("dominate primary notes").text();
            if (fruitArr.length > 0)
                arr.push(this.fruit(ripeness, dominate) + " notes of " + fruitArr.join(", ") + ".");
    
            // Herbaceous notes
            this.add(set, "herbaceous notes", arr, "Herbaceous notes of ", ".");
    
            // herbal notes
            this.add(set, "herbal notes", arr, "Herbal notes of ", ".");
    
            // spice notes
            this.add(set, "spice notes", arr, "Spice notes of ", ".");
    
            return arr.join(" ");
    }
}
