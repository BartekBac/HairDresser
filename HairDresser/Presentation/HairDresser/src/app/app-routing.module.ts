import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './authentication/guards/auth.guard';
import { Role } from './shared/enums/Role';


const routes: Routes = [
  { path: '', redirectTo: 'auth', pathMatch: 'full' },
  { path: '', children: [
    { path: 'auth', loadChildren: './authentication/authentication.module#AuthenticationModule'},
    { path: 'salon', loadChildren: './salon/salon.module#SalonModule', canActivate: [AuthGuard], data: {role: Role.salon}},
    { path: 'worker', loadChildren: './worker/worker.module#WorkerModule', canActivate: [AuthGuard], data: {role: Role.worker}},
    { path: 'client', loadChildren: './client/client.module#ClientModule', canActivate: [AuthGuard], data: {role: Role.client}}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
