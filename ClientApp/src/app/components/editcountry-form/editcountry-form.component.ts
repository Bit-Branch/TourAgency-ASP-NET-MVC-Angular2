import { CountryService } from 'src/app/services/country.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editcountry-form',
  templateUrl: './editcountry-form.component.html',
  styleUrls: ['./editcountry-form.component.css']
})
export class EditcountryFormComponent implements OnInit {

  country: any = {};

  constructor(private countryService: CountryService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.country.id = +p['id'];
                });
              }

  ngOnInit() {

    this.countryService.getCountry(this.country.id)
      .subscribe(v => {
        this.country = v;
      }, err => {
        if (err.status === 404) {
          this.router.navigate(['/home']);
        }
      });
  }

  submit() {
    if (this.country.id) {
      this.countryService.update(this.country)
        .subscribe(x => console.log(x));
    }
  }

  cancel() {
    if (confirm('Are you sure?')) {
          this.router.navigate(['/countries']);
        }
  }

}
