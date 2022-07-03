import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TastingSystem } from 'src/app/interfaces/tastingSystem';

@Injectable({
  providedIn: 'root'
})
export class TastingsService {

  constructor(private http: HttpClient) {   }  

  getTastingSystem(id: string): Observable<TastingSystem> {
    return this.http.get<TastingSystem>('./assets/system.json');
  }
}
