import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelService } from 'src/app/services/hotel.service';

@Component({
  selector: 'app-edithotel-form',
  templateUrl: './edithotel-form.component.html',
  styleUrls: ['./edithotel-form.component.css']
})
export class EdithotelFormComponent implements OnInit {

  countries: any[];
  hotels: any[];
  hotel: any = {
    id: 0,
    name: '',
    type: '',
    description: '',
    countryId: 0,
  };

  constructor(private hotelService: HotelService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.hotel.id = +p['id'];
                });
              }

  ngOnInit() {
    this.hotel.id = 0;

    this.hotelService.getHotel(this.hotel.id)
      .subscribe(v => {
        this.hotel = v;
      }, err => {
        if (err.status === 404) {
          this.router.navigate(['/home']);
        }
      });


    this.hotelService.getCountries().subscribe(countries => {
      console.log('countries', countries);
      this.countries = countries; });
  }

  onCountryChange() {
    console.log('Hotel', this.hotel);
  }

  private populateModels() {
    this.hotelService.getHotels().subscribe(hotels => {
      this.hotels = hotels;
    });
  }

  submit() {
    if (this.hotel.id) {
      this.hotelService.update(this.hotel)
        .subscribe(x => console.log(x));
    } else {
      this.hotelService.create(this.hotel)
        .subscribe(x => console.log(x));
    }
  }

  delete() {
    if (confirm('Are you sure?')) {
      this.hotelService.delete(this.hotel.id)
        .subscribe(x => {
          this.router.navigate(['/home']);
        });
    }
  }

}
