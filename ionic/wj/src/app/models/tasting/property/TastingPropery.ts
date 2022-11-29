import { TastingPropertyDisplayEnum } from "src/app/interfaces/TastingPropertyDisplayEnum";
import { TastingSystemProperty } from "src/app/interfaces/TastingSystemProperty";

export class TastingProperty {
    selectedValue: string;
    selectedValues: string[];
    isIncluded: boolean;
    title: string;
    values: string[];
    default: string;
    display: TastingPropertyDisplayEnum;
    order: number;
    subtitle: string;

    constructor(system: TastingSystemProperty) { 
        this.isIncluded = system.isIncluded;
        this.title = system.title;
        this.subtitle = system.subtitle;
        this.values = system.values;
        this.display = TastingPropertyDisplayEnum[system.display];
        this.selectedValue = this.isMultiSelect() ? null : system.default;
        this.selectedValues = null;
        this.order = system.order;
        if (this.display == TastingPropertyDisplayEnum.range) this.selectedValue = this.values[0];
    }

    text(): string {        
        if (!this.isIncluded) return null;
        if(this.isMultiSelect() && this.selectedValues)
            return this.selectedValues.join(", ");
        if(!this.isMultiSelect() && this.selectedValue)

        return null;
    }

    private isMultiSelect() {
        return this.display == TastingPropertyDisplayEnum.multiselect;
    }
}