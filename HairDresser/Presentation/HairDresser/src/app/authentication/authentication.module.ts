import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { PasswordModule, InputTextModule, PanelModule } from 'primeng/primeng';
import { HomeComponent } from './home/home.component';


@NgModule({
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    PasswordModule,
    PanelModule,
    InputTextModule
  ],
  declarations: [LoginComponent, HomeComponent]
})
export class AuthenticationModule { }
