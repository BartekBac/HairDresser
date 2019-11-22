import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WorkerResolver } from '../shared/resolvers/worker.resolver';


const workerRoutes: Routes = [
  {  path: '',
    component: HomeComponent,
    resolve: {
      worker: WorkerResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(workerRoutes)],
  exports: [RouterModule]
})
export class WorkerRoutingModule { }
