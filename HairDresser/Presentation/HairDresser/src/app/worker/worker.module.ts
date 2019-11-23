import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { WorkerRoutingModule } from './worker-routing.module';
import { HomeComponent } from './home/home.component';
import { WorkerVisitsComponent } from './visits/worker-visits/worker-visits.component';
import { TabMenuModule, PanelModule } from 'primeng/primeng';
import { WorkerCalendarComponent } from './visits/worker-calendar/worker-calendar.component';
import { FullCalendarModule } from 'primeng/fullcalendar';


@NgModule({
  declarations: [
    HomeComponent,
     WorkerVisitsComponent,
     WorkerCalendarComponent
  ],
  imports: [
    SharedModule,
    WorkerRoutingModule,
    TabMenuModule,
    PanelModule,
    FullCalendarModule
  ]
})
export class WorkerModule { }
