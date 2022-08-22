import { TastingSystem } from "src/app/interfaces/TastingSystem";
import { tastingStepperStateEnum } from "./tastingStepperStateEnum";
import { tastingStepperValueEnum } from "./tastingStepperValueEnum";
import { Tasting } from "./Tasting";

export class TastingStepper {
    private numberSteps: number = 7;
    currentStep: number = 1;
    progress: number = 0;
    steps: Array<string>;
    step: string;
    states: Array<tastingStepperStateEnum>;
    tasting: Tasting;
    nextStep: string;
    stepTitles: Array<string>;
    stepSubtitles: Array<string>;

    constructor(public system: TastingSystem) {
        this.steps = Object.values(tastingStepperValueEnum) as string[];
        this.stepTitles = ["Style", "Faults", "Fruits", "Florals", "Herbs & Spices"]
        this.stepSubtitles = ["select the style of wine", "does the wine exhibit any faults on the nose?", "does the wine exhibit any fruits on the nose?", "does the wine exhibit and floral notes on the nose",
    "does the wine exhibit any herbacesouse or spice notes on the nose?"];
        this.currentStep = 1;
        this.states = [tastingStepperStateEnum.todo, tastingStepperStateEnum.disabled, tastingStepperStateEnum.disabled, tastingStepperStateEnum.disabled, tastingStepperStateEnum.disabled, tastingStepperStateEnum.disabled, tastingStepperStateEnum.disabled]
       // this.setCurrentTab(this.steps[0]);
    }

    setCurrentTab(tab: string) {
        this.states[this.currentStep - 1] = tastingStepperStateEnum.complete;
        this.currentStep = this.steps.indexOf(tab) + 1;
        this.progress = this.currentStep / this.numberSteps - 1 / (2 * this.numberSteps);

        this.nextStep = (this.currentStep < this.steps.length - 1)
            ? this.steps[this.currentStep]
            : null;
    }

    isDisabled(tab: string) {
        var i = this.steps.indexOf(tab);
        return this.states[i] === tastingStepperStateEnum.disabled;
    }

    selectStyle(style: string) {
        this.states = [tastingStepperStateEnum.complete, tastingStepperStateEnum.todo, tastingStepperStateEnum.todo, tastingStepperStateEnum.todo, tastingStepperStateEnum.todo, tastingStepperStateEnum.todo, tastingStepperStateEnum.todo];
        this.setCurrentTab(tastingStepperValueEnum.appearance.toString());
        this.tasting = new Tasting(style, this.system);
        console.log('style seleced: ', this);
    }
}