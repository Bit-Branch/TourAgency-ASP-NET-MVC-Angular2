import { Component, OnInit } from '@angular/core';
import { SaleService } from 'src/app/services/sale.service';

@Component({
  selector: 'app-sales-form',
  templateUrl: './sales-form.component.html',
  styleUrls: ['./sales-form.component.css']
})
export class SalesFormComponent implements OnInit {
  private readonly PAGE_SIZE = 3;

  sales: any[];
  queryResult: any = {};
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  columns = [
    { title: 'Id' },
    { title: 'Buyer Name', key: 'personName', isSortable: true },
    { title: 'Price', key: 'tourPrice', isSortable: true },
    { title: 'Count', key: 'count', isSortable: true },
    { title: 'Sale Time', key: 'saleTime', isSortable: true },
    { }
  ];

  constructor(private saleService: SaleService) { }

  ngOnInit() {
    this.saleService.getSales()
      .subscribe(sales => this.sales = sales);

    this.populateServices();
  }

  private populateServices() {
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateServices();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateServices();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateServices();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateServices();
  }

}
