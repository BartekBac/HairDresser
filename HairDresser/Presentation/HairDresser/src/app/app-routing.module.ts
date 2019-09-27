import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'auth', pathMatch: 'full' },
  { path: '', children: [
    { path: 'auth', loadChildren: './authentication/authentication.module#AuthenticationModule'},
    { path: 'salon', loadChildren: './salon/salon.module#SalonModule'},
    { path: 'worker', loadChildren: './worker/worker.module#WorkerModule'},
    { path: 'client', loadChildren: './client/client.module#ClientModule'}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
