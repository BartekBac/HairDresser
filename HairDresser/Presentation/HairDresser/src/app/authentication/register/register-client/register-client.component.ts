import { Component, OnInit } from '@angular/core';
import { RegisterClientCredentials } from '../../models/RegisterClientCredentials';
import { ValidationMessage } from 'src/app/shared/models/ValidationMessage';

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.css']
})
export class RegisterClientComponent implements OnInit {

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

  constructor() { }

  ngOnInit() {
  }

  dataVaild(): ValidationMessage {
    let toReturn = new ValidationMessage(true, 'Success');
    if (this.registerCredentials.userData.password !== this.registerCredentials.userData.confirmPassword) {
      toReturn.update(false, "Confirm password don't match");
    } else if (!this.registerCredentials.userData.email.includes('@')) {
      toReturn.update(false, "Confirm password don't match");
    } else if (this.registerCredentials.firstName === '') {
      toReturn.update(false, "First name cannot by empty.");
    } else if (this.registerCredentials.lastName === '') {
      toReturn.update(false, "Last name cannot by empty.");
    } else if (this.registerCredentials.userData.password === '') {
      toReturn.update(false, "Password cannot by empty.");
    } else if (this.registerCredentials.userData.userName === '') {
      toReturn.update(false, "User name cannot by empty.");
    } else if (this.registerCredentials.userData.email === '') {
      toReturn.update(false, "Email cannot by empty.");
    } else if (this.registerCredentials.userData.phoneNumber === '') {
      toReturn.update(false, "Phone number cannot by empty.");
    }
    return toReturn;
  }

}
