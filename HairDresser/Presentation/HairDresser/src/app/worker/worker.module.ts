import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { WorkerRoutingModule } from './worker-routing.module';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    SharedModule,
    WorkerRoutingModule
  ]
})
export class WorkerModule { }
