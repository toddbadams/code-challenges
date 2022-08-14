export class TastingPropertyEvent {
    constructor(public readonly title: string,
        public readonly selectedValue: string,
        public readonly selectedValues: string[]) {}
}
