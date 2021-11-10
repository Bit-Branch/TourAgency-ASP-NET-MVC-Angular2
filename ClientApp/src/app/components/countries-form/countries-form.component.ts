import { CountryService } from './../../services/country.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-countries-form',
  templateUrl: './countries-form.component.html',
  styleUrls: ['./countries-form.component.css']
})
export class CountriesFormComponent implements OnInit {

  private readonly PAGE_SIZE = 3;

  countries: any[];
  columns = [
    { title: 'Id' },
    { title: 'Country Name', key: 'countryName', isSortable: true },
    { }
  ];
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  constructor(private countryService: CountryService) { }

  ngOnInit() {
    this.populateCountries();
  }

  private populateCountries() {
    this.countryService.getCountries()
      .subscribe(countries => {
        console.log('couhntries', countries);
      this.countries = countries; });
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateCountries();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateCountries();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateCountries();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateCountries();
  }

}
