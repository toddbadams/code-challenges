import { NoteWriter } from "src/app/interfaces/NoteWriter";
import { TastingSystemProperty } from "src/app/interfaces/TastingSystemProperty";
import { environment } from "src/environments/environment";
import { TastingPropertyEvent } from "./TastingPropertyEvent";
import { TastingPropertyIsIncludedEvent } from "./TastingPropertyIsIncludedEvent";
import { TastingProperty } from "./TastingPropery";


export class TastingPropertySet {
    properties: Array<TastingProperty>;
    note: string;

    constructor(public readonly title: string,
        public readonly wineStyle: string,
        public readonly writer: NoteWriter) { }

    protected setProperties(systemProperties: TastingSystemProperty[]) {
        this.properties = systemProperties.map(s => new TastingProperty(s));
        this.note = this.writer.write(this);
        this.sort();
    }

    sort() {
        this.properties.sort((n1: TastingProperty, n2: TastingProperty) => {
            if (n1.isIncluded > n2.isIncluded) return -1;
            if (n1.isIncluded < n2.isIncluded) return 1;
            if (n1.order > n2.order) return 1;
            if (n1.order < n2.order) return -1;
            return 0;
        });
    }

    getProperty(title: string): TastingProperty {
        var result = this.properties.find(e => e.title == title);
        if (result !== undefined) return result;
        if (!environment.production)
            console.log("TastingPropertySet getProperty: ", this);

        throw new Error("cannot find property: " + title);
    }

    isIncludedChangeEvent($event: TastingPropertyIsIncludedEvent) {
        var p = this.getProperty($event.title);
        p.isIncluded = $event.isIncluded;
        this.note = this.writer.write(this);
        this.sort();
    }

    propertyChangeEvent($event: TastingPropertyEvent) {
        var p = this.getProperty($event.title);
        p.selectedValue = $event.selectedValue;
        p.selectedValues = $event.selectedValues;
        this.note = this.writer.write(this);
    }
}
