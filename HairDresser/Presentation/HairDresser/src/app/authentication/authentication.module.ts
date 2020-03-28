import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { PasswordModule, InputTextModule, PanelModule, ButtonModule, DialogModule,
         MessageModule, TabViewModule, ScrollPanelModule, StepsModule } from 'primeng/primeng';
import { ContainerComponent } from './container/container.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegisterClientComponent } from './register/register-client/register-client.component';
import { RegisterSalonComponent } from './register/register-salon/register-salon.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    AuthenticationRoutingModule,
    PasswordModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    MessageModule,
    DialogModule,
    TabViewModule,
    FormsModule,
    HttpClientModule,
    ScrollPanelModule,
    StepsModule
  ],
  declarations: [LoginComponent, ContainerComponent, RegisterClientComponent, RegisterSalonComponent]
})
export class AuthenticationModule { }
