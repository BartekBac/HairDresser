import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { LoginCredential } from '../models/LoginCredential';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('login', null) loginInput: ElementRef;
  @ViewChild('password', null) passwordInput: ElementRef;
  @ViewChild('loginBtn', null) loginButton: ElementRef;

  protected displayRegisterClient = false;
  protected displayRegisterSalon = false;

  protected loginCredential: LoginCredential = {
    userName: '',
    password: ''
  };

  constructor(
    private authService: AuthService) { }

  ngOnInit() {
    this.focusLoginInput();
  }

  protected focusLoginInput() {
    this.loginInput.nativeElement.focus();
  }

  protected focusPasswordInput() {
    this.passwordInput.nativeElement.focus();
  }

  protected focusLoginButton() {
    this.loginButton.nativeElement.focus();
  }

  onKeydownLogin(event) {
    if (event.key === "Enter" || event.key === "ArrowDown") {
      this.focusPasswordInput()
    }
  }

  onKeydownPassword(event) {
    if (event.key === "Enter") {
      this.onSubmit();
    } else if (event.key === "ArrowUp") {
      this.focusLoginInput();
    } else if (event.key === "ArrowDown") {
      this.focusLoginButton();
    }
  }

  onKeydownLoginButton(event) {
    if (event.key === "ArrowUp") {
      this.focusPasswordInput()
    }
  }

  onSubmit() {
    this.authService.login(this.loginCredential).subscribe();
  }

  showRegisterClientDialog() {
    this.displayRegisterClient = true;
  }

  onCloseRegisterDialog(close: boolean) {
    this.displayRegisterClient = !close;
  }

  showRegisterSalonDialog() {
    this.displayRegisterSalon = true;
  }

}
