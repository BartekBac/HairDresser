import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SalonResolver } from '../shared/resolvers/salon.resolver';


const salonRoutes: Routes = [
  { path: '',
    component: HomeComponent,
    resolve: {
      salon: SalonResolver
    } }
];

@NgModule({
  imports: [RouterModule.forChild(salonRoutes)],
  exports: [RouterModule]
})
export class SalonRoutingModule { }
