import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-addcountry-form',
  templateUrl: './addcountry-form.component.html',
  styleUrls: ['./addcountry-form.component.css']
})
export class AddcountryFormComponent implements OnInit {
  country: any = {
    id: 0,
    name: ''
  };

  constructor(private countryService: CountryService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.country.id = +p['id'];
                });
              }

  ngOnInit() {
    this.country.id = 0;
  }

  submit() {
    if (this.country.id) {
      this.countryService.update(this.country)
        .subscribe(x => console.log(x));
    } else {
      this.countryService.create(this.country)
        .subscribe(x => console.log(x));
    }
  }

}
