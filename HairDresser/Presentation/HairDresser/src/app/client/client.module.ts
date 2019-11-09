import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ClientRoutingModule } from './client-routing.module';
import { HomeComponent } from './home/home.component';
import { TabMenuModule, ButtonModule, PanelModule } from 'primeng/primeng';
import { ClientSalonsComponent } from './salons/client-salons/client-salons.component';
import { ClientVisitsComponent } from './visits/client-visits/client-visits.component';
import { ClientOpinionsComponent } from './opinions/client-opinions/client-opinions.component';
import { ClientSalonsListElementComponent } from './salons/client-salons/client-salons-list-element/client-salons-list-element.component';


@NgModule({
  declarations: [
    HomeComponent,
    ClientSalonsComponent,
    ClientVisitsComponent,
    ClientOpinionsComponent,
    ClientSalonsListElementComponent
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
    TabMenuModule,
    ButtonModule,
    PanelModule
  ]
})
export class ClientModule { }
