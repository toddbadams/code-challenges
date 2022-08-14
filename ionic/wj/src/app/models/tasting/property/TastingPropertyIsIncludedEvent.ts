export class TastingPropertyIsIncludedEvent {
    constructor(public readonly title: string,
        public readonly isIncluded: boolean) {}
}
