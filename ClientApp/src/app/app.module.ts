
import { HotelService } from './services/hotel.service';
import { TourService } from './services/tour.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthModule } from '@auth0/auth0-angular';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AddtourFormComponent } from './components/addtour-form/addtour-form.component';
import { AddhotelFormComponent } from './components/addhotel-form/addhotel-form.component';
import { EdittourFormComponent } from './components/edittour-form/edittour-form.component';
import { EdithotelFormComponent } from './components/edithotel-form/edithotel-form.component';
import { HotelsFormComponent } from './components/hotels-form/hotels-form.component';
import { SalesFormComponent } from './components/sales-form/sales-form.component';
import { ToursFormComponent } from './components/tours-form/tours-form.component';
import { HotelFormComponent } from './components/hotel-form/hotel-form.component';
import { SaleFormComponent } from './components/sale-form/sale-form.component';
import { TourFormComponent } from './components/tour-form/tour-form.component';
import { AddcountryFormComponent } from './components/addcountry-form/addcountry-form.component';
import { CountriesFormComponent } from './components/countries-form/countries-form.component';
import { EditcountryFormComponent } from './components/editcountry-form/editcountry-form.component';
import { AuthButtonComponent } from './services/auth.service';
import { UserProfileComponent } from './services/user.info.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddtourFormComponent,
    AddhotelFormComponent,
    EdittourFormComponent,
    EdithotelFormComponent,
    HotelsFormComponent,
    CountriesFormComponent,
    SalesFormComponent,
    ToursFormComponent,
    HotelFormComponent,
    SaleFormComponent,
    TourFormComponent,
    AddcountryFormComponent,
    EditcountryFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AuthModule.forRoot({
      domain: 'dev-tpr8uqzh.us.auth0.com',
      clientId: '513ok9kNzkyWhpEFaafW9K45gC9SAFOT'
    }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },

      {path: 'tours/new', component: AddtourFormComponent},
      {path: 'hotels/new', component: AddhotelFormComponent},
      {path: 'countries/new', component: AddcountryFormComponent},

      {path: 'tours/edit/:id', component: EdittourFormComponent},
      {path: 'hotels/edit/:id', component: EdithotelFormComponent},

      {path: 'hotels/:id', component: HotelFormComponent},
      {path: 'tours/:id', component: TourFormComponent},
      {path: 'sales/:id', component: SaleFormComponent},

      {path: 'hotels', component: HotelsFormComponent},
      {path: 'tours', component: ToursFormComponent},
      {path: 'sales', component: SalesFormComponent},
      {path: 'countries', component: CountriesFormComponent},

      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [TourService, HotelService, AuthButtonComponent, UserProfileComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
