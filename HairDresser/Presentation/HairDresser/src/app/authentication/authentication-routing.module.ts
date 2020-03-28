import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContainerComponent } from './container/container.component';
import { RegisterSalonComponent } from './register/register-salon/register-salon.component';

const authenticationRoutes: Routes = [
  { path: '', component: ContainerComponent, },
  { path: 'register-salon', component: RegisterSalonComponent }
];

@NgModule({
  imports: [RouterModule.forChild(authenticationRoutes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
