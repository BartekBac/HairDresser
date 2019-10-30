import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SalonRoutingModule } from './salon-routing.module';
import { HomeComponent } from './home/home.component';
import { CardModule, AccordionModule, ButtonModule, DialogModule, PanelModule,
         TabViewModule, InputTextModule, MessageModule, CarouselModule } from 'primeng/primeng';
import { AddWorkerComponent } from './workers/add-worker/add-worker.component';
import { FormsModule } from '@angular/forms';
import { WorkerListElementViewComponent } from './workers/worker-list-element-view/worker-list-element-view.component';
import { WorkerListComponent } from './workers/worker-list/worker-list.component';


@NgModule({
  declarations: [HomeComponent, AddWorkerComponent, WorkerListElementViewComponent, WorkerListComponent],
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
    MessageModule,
    CarouselModule
  ]
})
export class SalonModule { }
