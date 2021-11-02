import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  constructor(private httpClient: HttpClient ) { }

  getFeatures() {
    return this.httpClient.get('/api/tours').pipe(map((res: any) => res.json()));
  }
}
