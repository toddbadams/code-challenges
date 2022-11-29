import { TastingSystem } from "src/app/interfaces/TastingSystem";
import { TastingSystemStep } from "src/app/interfaces/TastingSystemStep";
import { environment } from "src/environments/environment";
import { TastingPropertyEvent } from "./property/TastingPropertyEvent";
import { TastingPropertyIsIncludedEvent } from "./property/TastingPropertyIsIncludedEvent";
import { TastingProperty } from "./property/TastingPropery";

export class Tasting {
    note: string = null;
    featured_image: string;
    seo_title: string;
    published: Date;
    gps: string;
    producer: string;
    vintage: number;
    region: string;
    variety: string;
    summary: string;
    steps: Array<TastingSystemStep>
    properties: Array<TastingProperty>

    constructor(system: TastingSystem) {
        this.steps = system.steps;
        this.properties = system.properties.map(p => new TastingProperty(p));
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
       // this.note = this.writer.write(this);
        this.sort();
    }

    propertyChangeEvent($event: TastingPropertyEvent) {
        var p = this.getProperty($event.title);
        p.selectedValue = $event.selectedValue;
        p.selectedValues = $event.selectedValues;
       // this.note = this.writer.write(this);
    }
}

