import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { RegisterClientCredentials } from '../../models/RegisterClientCredentials';
import { ValidationMessage } from 'src/app/shared/models/ValidationMessage';
import { AuthService } from '../../services/auth.service';
import { MessageService } from 'primeng/primeng';

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.css']
})
export class RegisterClientComponent implements OnInit {

  @Output() closeDialog = new EventEmitter<boolean>();

  protected registerCredentials: RegisterClientCredentials = {
    firstName: '',
    lastName: '',
    userData: {
      userName: '',
      password: '',
      confirmPassword: '',
      email: '',
      phoneNumber: '',
      role: 'client'
    }
  };

  protected validationMessage: ValidationMessage = null;

  constructor(
    private authService: AuthService,
    private toastService: MessageService) { }

  ngOnInit() {
  }

  dataValid(): ValidationMessage {
    let toReturn = new ValidationMessage(true, 'Data valid');
    if (this.registerCredentials.firstName === '') {
      toReturn.update(false, "First name cannot by empty.");
    } else if (this.registerCredentials.lastName === '') {
      toReturn.update(false, "Last name cannot by empty.");
    }  else if (this.registerCredentials.userData.userName === '') {
      toReturn.update(false, "User name cannot by empty.");
    } else if (this.registerCredentials.userData.password === '') {
      toReturn.update(false, "Password cannot by empty.");
    } else if (this.registerCredentials.userData.email === '') {
      toReturn.update(false, "Email cannot by empty.");
    } else if (this.registerCredentials.userData.phoneNumber === '') {
      toReturn.update(false, "Phone number cannot by empty.");
    } else if (this.registerCredentials.userData.password !== this.registerCredentials.userData.confirmPassword) {
      toReturn.update(false, "Confirm password don't match");
    } else if (!this.registerCredentials.userData.email.includes('@')) {
      toReturn.update(false, "E-mail don't include @");
    }
    return toReturn;
  }

  submit() {
    this.validationMessage = this.dataValid();
    if (this.validationMessage.isValid) {
      this.authService.registerClient(this.registerCredentials).subscribe(
        res => {
          this.closeDialog.emit(this.validationMessage.isValid);
          this.toastService.add({severity: 'success', summary: 'Register succeeded', detail: 'Client account created'});
        },
        err => this.toastService.add({severity: 'error', summary: 'Register failed', detail: err.error})
      );
    }
  }

}
