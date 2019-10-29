import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SalonRoutingModule } from './salon-routing.module';
import { HomeComponent } from './home/home.component';
import { CardModule, AccordionModule, ButtonModule, DialogModule, PanelModule,
         TabViewModule, InputTextModule, MessageModule } from 'primeng/primeng';
import { AddWorkerComponent } from './add-worker/add-worker.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [HomeComponent, AddWorkerComponent],
  imports: [
    SharedModule,
    SalonRoutingModule,
    CardModule,
    AccordionModule,
    ButtonModule,
    DialogModule,
    PanelModule,
    TabViewModule,
    InputTextModule,
    FormsModule,
    MessageModule
  ]
})
export class SalonModule { }
