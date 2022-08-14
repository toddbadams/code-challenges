import { TastingPropertyDisplayEnum } from "src/app/interfaces/TastingPropertyDisplayEnum";
import { TastingSystemProperty } from "src/app/interfaces/TastingSystemProperty";

export class TastingProperty {
    selectedValue: string;
    selectedValues: string[];
    isIncluded: boolean;
    isMultiSelect: boolean;
    title: string;
    values: string[];
    default: string;
    display: TastingPropertyDisplayEnum;
    order: number;

    constructor(system: TastingSystemProperty) { 
        this.isIncluded = system.isIncluded;
        this.isMultiSelect = system.isMultiSelect;
        this.title = system.title;
        this.values = system.values;
        this.selectedValue = this.isMultiSelect ? null : system.default;
        this.selectedValues = null;
        this.display = TastingPropertyDisplayEnum[system.display];
        this.order = system.order;
        if (this.display == TastingPropertyDisplayEnum.range) this.selectedValue = this.values[0];
    }

    text(): string {        
        if (!this.isIncluded) return null;
        if(this.isMultiSelect && this.selectedValues)
            return this.selectedValues.join(", ");
        if(!this.isMultiSelect && this.selectedValue)
            return this.selectedValue;
        return null;
    }
}


