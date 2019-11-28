import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ClientRoutingModule } from './client-routing.module';
import { HomeComponent } from './home/home.component';
import { TabMenuModule, ButtonModule, PanelModule, AccordionModule, CardModule,
         OverlayPanelModule, DropdownModule, SelectButtonModule, AutoCompleteModule,
         DialogModule, ListboxModule, ScrollPanelModule, CheckboxModule, RatingModule } from 'primeng/primeng';
import { ClientSalonsComponent } from './salons/client-salons/client-salons.component';
import { ClientVisitsComponent } from './visits/client-visits/client-visits.component';
import { ClientOpinionsComponent } from './opinions/client-opinions/client-opinions.component';
import { ClientSalonsListElementComponent } from './salons/client-salons/salons-list-element/salons-list-element.component';
import { ClientSalonSelectedCardComponent } from './salons/client-salons/salon-selected-card/salon-selected-card.component';
import { ClientSalonWorkersListComponent } from './salons/client-salons/salon-selected-card/workers-list/workers-list.component';
import { WorkersListElementComponent } from './salons/client-salons/salon-selected-card/workers-list/workers-list-element/workers-list-element.component';
import { WorkerSelectedCardComponent } from './salons/client-salons/salon-selected-card/workers-list/worker-selected-card/worker-selected-card.component';
import { AddSalonComponent } from './salons/add-salon/add-salon.component';
import { DataViewModule } from 'primeng/dataview';
import { SalonListElementComponent } from './salons/add-salon/salon-list-element/salon-list-element.component';
import { FormsModule } from '@angular/forms';
import { MakeAppointmentComponent } from './salons/make-appointment/make-appointment.component';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { NgbTooltipModule, NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    HomeComponent,
    ClientSalonsComponent,
    ClientVisitsComponent,
    ClientOpinionsComponent,
    ClientSalonsListElementComponent,
    ClientSalonSelectedCardComponent,
    ClientSalonWorkersListComponent,
    WorkersListElementComponent,
    WorkerSelectedCardComponent,
    AddSalonComponent,
    SalonListElementComponent,
    MakeAppointmentComponent
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
    TabMenuModule,
    ButtonModule,
    PanelModule,
    AccordionModule,
    CardModule,
    OverlayPanelModule,
    DataViewModule,
    DropdownModule,
    FormsModule,
    SelectButtonModule,
    AutoCompleteModule,
    DialogModule,
    ListboxModule,
    ScrollPanelModule,
    ProgressSpinnerModule,
    NgbTooltipModule,
    CheckboxModule,
    RatingModule,
    NgbRatingModule
  ]
})
export class ClientModule { }
