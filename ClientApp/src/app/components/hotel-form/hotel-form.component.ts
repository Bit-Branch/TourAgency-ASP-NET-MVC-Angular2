import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelService } from 'src/app/services/hotel.service';

@Component({
  selector: 'app-hotel-form',
  templateUrl: './hotel-form.component.html',
  styleUrls: ['./hotel-form.component.css']
})
export class HotelFormComponent implements OnInit {
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
  }

  edit() {
    if (this.hotel.id) {
      this.router.navigate([`/hotels/edit/${this.hotel.id}`]);
    } else {
      this.router.navigate(['/home']);
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
