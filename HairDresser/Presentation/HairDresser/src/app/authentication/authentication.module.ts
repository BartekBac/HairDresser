import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { PasswordModule, InputTextModule, PanelModule, ButtonModule, InputMaskModule,
         DialogModule, MessageModule, TabViewModule, SelectButtonModule } from 'primeng/primeng';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserDataComponent } from './register/user-data/user-data.component';
import { RegisterClientComponent } from './register/register-client/register-client.component';
import { RegisterSalonComponent } from './register/register-salon/register-salon.component';
import { SharedModule } from '../shared/shared.module';
import { NgbModule, NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    AuthenticationRoutingModule,
    PasswordModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    InputMaskModule,
    MessageModule,
    DialogModule,
    TabViewModule,
    SelectButtonModule,
    FormsModule,
    HttpClientModule
  ],
  declarations: [LoginComponent, HomeComponent, UserDataComponent, RegisterClientComponent, RegisterSalonComponent]
})
export class AuthenticationModule { }
