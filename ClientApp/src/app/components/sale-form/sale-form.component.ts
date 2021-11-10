import { SaleService } from 'src/app/services/sale.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sale-form',
  templateUrl: './sale-form.component.html',
  styleUrls: ['./sale-form.component.css']
})
export class SaleFormComponent implements OnInit {

  sale: any = {};

  constructor(private saleService: SaleService,
              private route: ActivatedRoute,
              private router: Router) {
                route.params.subscribe(p => {
                  this.sale.id = +p['id'];
                });
              }

  ngOnInit() {

    this.saleService.getSale(this.sale.id)
      .subscribe(v => {
        this.sale = v;
      }, err => {
        if (err.status === 404) {
          this.router.navigate(['/home']);
        }
      });
  }

  edit() {
    if (this.sale.id) {
      this.router.navigate([`/sales/edit/${this.sale.id}`]);
    } else {
      this.router.navigate(['/home']);
    }
  }

  delete() {
    if (confirm('Are you sure?')) {
      this.saleService.delete(this.sale.id)
        .subscribe(x => {
          this.router.navigate(['/home']);
        });
    }
  }

}
