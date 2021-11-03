import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  private readonly toursEndpoint = '/api/tours';

  constructor(private httpClient: HttpClient ) { }

  getTours() {
    return this.httpClient.get(this.toursEndpoint).pipe(map((res: any) => res));
  }

  getTour(id) {
    return this.httpClient.get(this.toursEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }

  create(tour) {
    return this.httpClient.post(this.toursEndpoint, tour).pipe(map((res: any) => res));
  }

  update(tour) {
    return this.httpClient.put(this.toursEndpoint + '/' + tour.id, tour)
      .pipe(map((res: any) => res));
  }

  delete(id) {
    return this.httpClient.delete(this.toursEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }
}
