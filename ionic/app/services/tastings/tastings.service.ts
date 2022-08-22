import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TastingSystem } from 'src/app/interfaces/tastingSystem';
import { Tasting } from 'src/app/models/tasting/Tasting';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/compat/firestore';
import { TastingStepper } from 'src/app/models/tasting/TastingStepper';

@Injectable({
  providedIn: 'root'
})
export class TastingsService {
  stepper: TastingStepper;
  currentTasting: Tasting;
  private tastings: Observable<Tasting[]>;
  private tastingCollection: AngularFirestoreCollection<Tasting>;

  constructor(private http: HttpClient, afs: AngularFirestore) {
    this.tastingCollection = afs.collection<Tasting>('tasting');
    this.tastings = this.tastingCollection.valueChanges();
  }

  getTastingSystem(): Observable<TastingSystem> {
    return this.http.get<TastingSystem>('./assets/system.json');
  }

  getRegions(): Observable<string[]> {
    return this.http.get<string[]>('./assets/regions.json');
  }

  createTasting(tasting: Tasting): any {
    return this.tastingCollection.add(structuredClone(tasting));
  }

  getTastings(): Observable<Tasting[]> {
    return this.tastings;
  }

  createStepper(system: TastingSystem): TastingStepper {
    this.stepper = new TastingStepper(system);
    return this.stepper;
  }

  getStepper(): TastingStepper {
    return this.stepper;
  }
}


