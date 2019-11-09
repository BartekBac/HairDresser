import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClientResolver } from '../shared/resolvers/client.resolver';


const clientRoutes: Routes = [
  { path: '',
    component: HomeComponent,
    resolve: {
      client: ClientResolver
    } }
];

@NgModule({
  imports: [RouterModule.forChild(clientRoutes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
