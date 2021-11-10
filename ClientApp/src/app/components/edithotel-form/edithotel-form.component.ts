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
  hotel: any = {};

  constructor(private hotelService: HotelService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.hotel.id = +p['id'];
                });
              }

  ngOnInit() {

    this.hotelService.getHotel(this.hotel.id)
      .subscribe(v => {
        this.hotel = v;
      }, err => {
        if (err.status === 404) {
          this.router.navigate(['/home']);
        }
      });

      this.hotelService.getCountries().subscribe(countries =>
        this.countries = countries);
  }

  submit() {
    if (this.hotel.id) {
      this.hotelService.update(this.hotel)
        .subscribe(x => console.log(x));
    }
  }

  cancel() {
    if (confirm('Are you sure?')) {
          this.router.navigate(['/hotels']);
        }
  }

}
