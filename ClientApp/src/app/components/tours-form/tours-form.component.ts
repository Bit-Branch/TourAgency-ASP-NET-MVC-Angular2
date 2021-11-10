import { TourService } from './../../services/tour.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tours-form',
  templateUrl: './tours-form.component.html',
  styleUrls: ['./tours-form.component.css']
})
export class ToursFormComponent implements OnInit {

  private readonly PAGE_SIZE = 3;

  queryResult: any = {};
  tours: any[];
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Tour Name', key: 'tourName', isSortable: true },
    { title: 'Price', key: 'price', isSortable: true },
    { title: 'Departure City', key: 'departureCity', isSortable: true },
    { title: 'Departure Time', key: 'departureTime', isSortable: true },
    { title: 'Hotel', key: 'hotel', isSortable: true },
    { title: 'Days Count', key: 'daysCount', isSortable: true },
    { title: 'Nights Count', key: 'nightsCount', isSortable: true },
    { }
  ];

  constructor(private tourService: TourService) { }

  ngOnInit() {
    this.populateTours();
  }

  private populateTours() {
    this.tourService.getTours()
      .subscribe(tours => {
        console.log('tours', tours);
      this.tours = tours; });
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateTours();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateTours();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateTours();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateTours();
  }

}
