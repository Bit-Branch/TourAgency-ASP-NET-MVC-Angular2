import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TourService } from 'src/app/services/tour.service';

@Component({
  selector: 'app-edittour-form',
  templateUrl: './edittour-form.component.html',
  styleUrls: ['./edittour-form.component.css']
})
export class EdittourFormComponent implements OnInit {
  tour: any = {};
  hotels: any[];

  constructor(private tourService: TourService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.tour.id = +p['id'];
                });
              }

  ngOnInit() {

    this.tourService.getTour(this.tour.id)
      .subscribe(v => {
        this.tour = v;
      }, err => {
        if (err.status === 404) {
          this.router.navigate(['/home']);
        }
      });

      this.tourService.getHotels().subscribe(hotels =>
        this.hotels = hotels);
  }

  submit() {
    if (this.tour.id) {
      this.tourService.update(this.tour)
        .subscribe(x => console.log(x));
    }
  }

  cancel() {
    if (confirm('Are you sure?')) {
          this.router.navigate(['/tours']);
        }
  }


}
