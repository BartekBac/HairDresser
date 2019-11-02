import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SalonRoutingModule } from './salon-routing.module';
import { HomeComponent } from './home/home.component';
import { CardModule, AccordionModule, ButtonModule, DialogModule, PanelModule,
         TabViewModule, InputTextModule, MessageModule, CarouselModule, KeyFilterModule} from 'primeng/primeng';
import { AddWorkerComponent } from './workers/add-worker/add-worker.component';
import { FormsModule } from '@angular/forms';
import { WorkerListElementViewComponent } from './workers/worker-list-element-view/worker-list-element-view.component';
import { WorkerListComponent } from './workers/worker-list/worker-list.component';
import { AddServiceComponent } from './services/add-service/add-service.component';
import { ServiceListComponent } from './services/service-list/service-list.component';
import { ServiceListElementComponent } from './services/service-list-element/service-list-element.component';


@NgModule({
  declarations: [
    HomeComponent,
    AddWorkerComponent,
    WorkerListElementViewComponent,
    WorkerListComponent,
    AddServiceComponent,
    ServiceListComponent,
    ServiceListElementComponent
  ],
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
    CarouselModule,
    KeyFilterModule
  ]
})
export class SalonModule { }
