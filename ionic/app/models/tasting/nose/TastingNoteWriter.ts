import { TastingPropertySet } from "src/app/models/tasting/property/TastingPropertySet";


export class TastingNoteWriter {

    cap(a: string) {
        return a.charAt(0).toUpperCase() + a.slice(1);
    }

    add(set: TastingPropertySet, title: string, arr: Array<string>, before?: string, after?: string) {
        const text = set.getProperty(title).text();
        if (text != null)
            arr.push((before ? before : "") + text + (after ? after : ""));
    }

    
    two(a: string, b: string, m: string): string {
        if (a != null && b != null )
            return a + m + b;
        if ((a !=null) || (b != null))
            return a || b;
        return null;
    }

    
    fruit(a: string, b: string): string {
        if (a != null && b != null)
            return this.cap(a) + " and " + b;
        if (a != null)
            return this.cap(a) + "fruit";
        if (b != null)
            return this.cap(b);
        return "Fruit";
    }

}
