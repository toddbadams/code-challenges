import { TastingSystemAppearance } from "src/app/interfaces/TastingSystemAppearance";


export class TastingAppearance {
    color: string;
    baseColor: string;
    intensity: string;
    brightness: string;
    clarity: string;
    note: string;

    constructor(public system: TastingSystemAppearance) {
        this.brightness = this.system.brightness[0];
        this.clarity = this.system.clarity[0];
        this.intensity = this.system.intensities[0];
        this.baseColor = this.system.baseColors[0];
        this.color = this.system.whites[0];
        this.writeNote();
    }

    writeNote(){
        this.note = `${this.brightness} and ${this.clarity} ${this.intensity} ${this.color} colour.` ;
      }
}
