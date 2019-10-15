import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ClientRoutingModule } from './client-routing.module';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    SharedModule,
    ClientRoutingModule
  ]
})
export class ClientModule { }
