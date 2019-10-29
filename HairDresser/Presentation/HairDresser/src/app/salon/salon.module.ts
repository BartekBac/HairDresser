import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SalonRoutingModule } from './salon-routing.module';
import { HomeComponent } from './home/home.component';
import { CardModule, AccordionModule, ButtonModule, DialogModule } from 'primeng/primeng';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    SharedModule,
    SalonRoutingModule,
    CardModule,
    AccordionModule,
    ButtonModule,
    DialogModule
  ]
})
export class SalonModule { }
