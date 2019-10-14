import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { RegisterSalonCredentials } from '../../models/RegisterSalonCredentials';
import { SelectItem } from 'primeng/primeng';
import { AuthService } from '../../services/auth.service';
import { ValidationMessage } from 'src/app/shared/models/ValidationMessage';

@Component({
  selector: 'app-register-salon',
  templateUrl: './register-salon.component.html',
  styleUrls: ['./register-salon.component.css']
})
export class RegisterSalonComponent implements OnInit {

  @Output() closeDialog = new EventEmitter<boolean>();

  protected tabIndex = 0;

  salonTypes: SelectItem[] = [
    {label: 'Unisex', value: 0},
    {label: 'Female', value: 1},
    {label: 'Male', value: 2}
  ];

  protected registerCredentials: RegisterSalonCredentials = {
    name: '',
    additionalInfo: '',
    type: 0,
    address: {
      city: '',
      zipCode: '',
      street: '',
      houseNumber: '',
    },
    userData: {
      userName: '',
      password: '',
      confirmPassword: '',
      email: '',
      phoneNumber: '',
      role: 'salon'
    }
  };

  protected validationMessage: ValidationMessage = null;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  dataValid(): ValidationMessage {
    let toReturn = new ValidationMessage(true, 'Success');
    if (this.registerCredentials.userData.userName === '') {
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
    } else if (this.registerCredentials.name === '') {
      toReturn.update(false, "Salon name cannot by empty.");
    } else if (this.registerCredentials.address.city === '') {
      toReturn.update(false, "City cannot by empty.");
    } else if (this.registerCredentials.address.street === '') {
      toReturn.update(false, "Street cannot by empty.");
    } else if (this.registerCredentials.address.zipCode === '') {
      toReturn.update(false, "Zip code cannot by empty.");
    }
    return toReturn;
  }

  submit() {
    this.validationMessage = this.dataValid();
    if (this.validationMessage.isValid) {
      this.authService.registerSalon(this.registerCredentials).subscribe(
        res => setTimeout( () => this.closeDialog.emit(this.validationMessage.isValid), 2000 )
      );
    }
  }

}
