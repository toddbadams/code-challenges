import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TastingSystem } from 'src/app/interfaces/TastingSystem';
import { Tasting } from 'src/app/models/tasting/Tasting';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/compat/firestore';

@Injectable({
  providedIn: 'root'
})
export class TastingsService {
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
}


