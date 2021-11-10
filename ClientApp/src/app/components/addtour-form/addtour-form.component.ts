import { TourService } from './../../services/tour.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-addtour-form',
  templateUrl: './addtour-form.component.html',
  styleUrls: ['./addtour-form.component.css']
})
export class AddtourFormComponent implements OnInit {
  countries: any[];
  hotels: any[];
  tour: any = {
    id: 0,
    name: '',
    price: 0,
    departureTime: {},
    departureCity: '',
    daysCount: 0,
    nightsCount: 0
  };

  constructor(private tourService: TourService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.tour.id = +p['id'];
                });
              }

  ngOnInit() {
    this.tour.id = 0;
    this.tourService.getHotels().subscribe(hotels => {
      console.log('hotels', hotels);
      this.hotels = hotels; });
  }

  submit() {
    if (this.tour.id) {
      this.tourService.update(this.tour)
        .subscribe(x => console.log(x));
    } else {
      this.tourService.create(this.tour)
        .subscribe(x => console.log(x));
    }
  }

}
