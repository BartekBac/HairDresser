import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClientResolver } from '../shared/resolvers/client.resolver';
import { ClientAddSalonResolver } from '../shared/resolvers/client-add-salon.resolver';
import { AddSalonComponent } from './salons/add-salon/add-salon.component';


const clientRoutes: Routes = [
  { path: '',
    component: HomeComponent,
    resolve: {
      client: ClientResolver
    }
  },
  { path: 'add-salon',
    component: AddSalonComponent,
    resolve: {
      salons: ClientAddSalonResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(clientRoutes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
