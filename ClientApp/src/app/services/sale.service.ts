import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SaleService {

  private readonly salesEndpoint = '/api/sales';

  constructor(private httpClient: HttpClient ) { }

  getSales() {
    return this.httpClient.get(this.salesEndpoint).pipe(map((res: any) => res));
  }

  getSale(id) {
    return this.httpClient.get(this.salesEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }

  create(sale) {
    return this.httpClient.post(this.salesEndpoint, sale).pipe(map((res: any) => res));
  }

  update(sale) {
    return this.httpClient.put(this.salesEndpoint + '/' + sale.id, sale)
      .pipe(map((res: any) => res));
  }

  delete(id) {
    return this.httpClient.delete(this.salesEndpoint + '/' + id)
      .pipe(map((res: any) => res));
  }
}
