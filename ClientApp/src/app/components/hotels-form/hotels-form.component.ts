import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hotels-form',
  templateUrl: './hotels-form.component.html',
  styleUrls: ['./hotels-form.component.css']
})
export class HotelsFormComponent implements OnInit {
  hotels: any[];
  countries: any[];
  columns: any[];

  constructor() { }

  ngOnInit() {
  }

}
