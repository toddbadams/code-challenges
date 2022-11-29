import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";
import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { environment } from "src/environments/environment";
import { TastingNoteWriter } from "../nose/TastingNoteWriter";


export class TastingAppearanceNoteWriter  extends TastingNoteWriter implements NoteWriter {

    write(set: TastingPropertySet): string {
        if (!environment.production)
            console.log("TastingAppearanceNoteWriter write: ", set);

            
        var arr = new Array<string>();

        var bc = this.two(set.getProperty("brightness").text(), set.getProperty("clarity").text(), " and ");
        var cc = this.two(set.getProperty("concentration").text(), set.getProperty(set.wineStyle).text(), " ");

        if (bc && cc)
            bc += ", with a";
        if (cc)
            cc += " colour";
            
        arr.push("The wine is");
        if (bc)
            arr.push(bc);
        if (cc)
            arr.push(cc);
            
        this.add(set, "sediment", arr, "showing ", " sediments");
        return arr.join(" ") + ".";
    }


}
