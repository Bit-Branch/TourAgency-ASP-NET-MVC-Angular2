import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private readonly countriesEndpoint = '/api/countries';

  constructor(private httpClient: HttpClient ) { }

  getCountries() {
    return this.httpClient.get(this.countriesEndpoint).pipe(map((res: any) => res));
  }

  getCountry(id) {
    return this.httpClient.get(this.countriesEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }

  create(country) {
    return this.httpClient.post(this.countriesEndpoint, country).pipe(map((res: any) => res));
  }

  update(country) {
    return this.httpClient.put(this.countriesEndpoint + '/' + country.id, country)
      .pipe(map((res: any) => res));
  }

  delete(id) {
    return this.httpClient.delete(this.countriesEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }
}
