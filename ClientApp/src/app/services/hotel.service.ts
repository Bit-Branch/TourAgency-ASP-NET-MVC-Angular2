import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HotelService {

  private readonly hotelsEndpoint = '/api/hotels';

  constructor(private httpClient: HttpClient ) { }

  getHotels() {
    return this.httpClient.get(this.hotelsEndpoint).pipe(map((res: any) => res));
  }

  getHotel(id) {
    return this.httpClient.get(this.hotelsEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }

  getCountries() {
    return this.httpClient.get('/api/countries').pipe(map((res: any) => res));
  }

  create(hotel) {
    return this.httpClient.post(this.hotelsEndpoint, hotel).pipe(map((res: any) => res));
  }

  update(hotel) {
    return this.httpClient.put(this.hotelsEndpoint + '/' + hotel.id, hotel)
      .pipe(map((res: any) => res));
  }

  delete(id) {
    return this.httpClient.delete(this.hotelsEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }
}
