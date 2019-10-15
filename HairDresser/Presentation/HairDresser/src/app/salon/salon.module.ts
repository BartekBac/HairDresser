import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SalonRoutingModule } from './salon-routing.module';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    SharedModule,
    SalonRoutingModule
  ]
})
export class SalonModule { }
