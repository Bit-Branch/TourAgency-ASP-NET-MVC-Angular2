import { TourService } from 'src/app/services/tour.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css']
})
export class TourFormComponent implements OnInit {

  tour: any = {};

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
        console.log('tour', v);
      }, err => {
        if (err.status === 404) {
          this.router.navigate(['/home']);
        }
      });
  }

  edit() {
    if (this.tour.id) {
      this.router.navigate([`/tours/edit/${this.tour.id}`]);
    } else {
      this.router.navigate(['/home']);
    }
  }

  delete() {
    if (confirm('Are you sure?')) {
      this.tourService.delete(this.tour.id)
        .subscribe(x => {
          this.router.navigate(['/home']);
        });
    }
  }

  buyTour() {
  }

}
