import { TastingSystemNose } from "src/app/interfaces/TastingSystemNose";

export class TastingNose {
    isVisible: boolean;
    intensity: string;
    aromas: string[];
    ripeness: string;
    floral: string[];
    greenFruit: string[];
    citrusFruit: string[];
    stoneFruit: string[];
    tropicalFruit: string[];
    redFruit: string[];
    blackFruit: string[];
    herbaceous: string[];
    herbal: string[];
    spice: string[];
    note: string;

    constructor(public system: TastingSystemNose) {
        this.intensity = this.system.intensities[0];
        this.ripeness = this.system.ripeness[0];
        this.writeNote();
    }

    writeNote() {
        this.note = this.writeFruits()
            + this.writeFlorals()
            + this.writeHerbaceous()
            + this.writeHerbal()
            + this.writeSpice();
      }

    private writeFruits(): string {
        if (this.hasNoFruits()) return "";

        let x = `${this.intensity} ${this.ripeness} fruits of `;
        if(this.greenFruit) x += this.greenFruit.join(', ') + ', ';
        if(this.citrusFruit) x += this.citrusFruit.join(', ') + ', ';
        if(this.stoneFruit) x += this.stoneFruit.join(', ') + ', ';
        if(this.tropicalFruit) x += this.tropicalFruit.join(', ') + ', ';
        if(this.blackFruit) x += this.blackFruit.join(', ') + ', ';
        if(this.redFruit) x += this.redFruit.join(', ') + ', ';
        x = x.slice(0,-2) + '.';
        return x;
    }

    private writeFlorals(): string {
        if (this.hasNoFloral()) return "";

        let x = ` Floral notes of `;
        if(this.floral) x += this.floral.join(', ') + '.';
        return x;
    }

    private writeHerbaceous(): string {
        if (this.hasNoHerbaceous()) return "";

        let x = ` Herbaceous notes of `;
        if(this.herbaceous) x += this.herbaceous.join(', ') + '.';
        return x;
    }

    private writeHerbal(): string {
        if (this.hasNoHerbal()) return "";

        let x = ` Herbal notes of `;
        if(this.herbal) x += this.herbal.join(', ') + '.';
        return x;
    }

    private writeSpice(): string {
        if (this.hasNoSpice()) return "";

        let x = ` Spice notes of `;
        if(this.spice) x += this.spice.join(', ') + '.';
        return x;
    }


    private hasNoFruits(): boolean{
        return (this.greenFruit === undefined || this.greenFruit.length == 0)
            && (this.citrusFruit  === undefined || this.citrusFruit.length == 0)
            && (this.greenFruit  === undefined || this.greenFruit.length == 0)
            && (this.stoneFruit  === undefined || this.stoneFruit.length == 0)
            && (this.tropicalFruit  === undefined || this.tropicalFruit.length == 0)
            && (this.redFruit === undefined || this.redFruit.length == 0)
            && (this.blackFruit === undefined || this.blackFruit.length == 0);
    }

    private hasNoFloral(): boolean{
        return (this.floral === undefined || this.floral.length == 0);
    }

    private hasNoHerbaceous(): boolean{
        return (this.herbaceous === undefined || this.herbaceous.length == 0);
    }

    private hasNoHerbal(): boolean{
        return (this.herbal === undefined || this.herbal.length == 0);
    }

    private hasNoSpice(): boolean{
        return (this.spice === undefined || this.spice.length == 0);
    }
}
