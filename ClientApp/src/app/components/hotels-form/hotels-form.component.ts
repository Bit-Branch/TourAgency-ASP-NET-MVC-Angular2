import { HotelService } from 'src/app/services/hotel.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hotels-form',
  templateUrl: './hotels-form.component.html',
  styleUrls: ['./hotels-form.component.css']
})
export class HotelsFormComponent implements OnInit {
  private readonly PAGE_SIZE = 3;

  hotels: any[];
  countries: any[];
  columns = [
    { title: 'Id' },
    { title: 'Hotel Name', key: 'hotelName', isSortable: true },
    { title: 'Country', key: 'country', isSortable: true },
    { title: 'Description', key: 'description', isSortable: true },
    { }
  ];
  query: any = {
    pageSize: this.PAGE_SIZE
  };

  constructor(private hotelService: HotelService) { }

  ngOnInit() {
    this.populateHotels();
  }

  private populateHotels() {
    this.hotelService.getHotels()
      .subscribe(hotels => {
      console.log('hotels', hotels);
      this.hotels = hotels; });
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateHotels();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateHotels();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateHotels();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateHotels();
  }

}
