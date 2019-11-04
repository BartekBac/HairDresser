import { Component, OnInit, Input } from '@angular/core';
import { UserData } from '../../models/UserData';

@Component({
  selector: 'app-form-user-data',
  templateUrl: './form-user-data.component.html',
  styleUrls: ['./form-user-data.component.css']
})
export class FormUserDataComponent implements OnInit {

  @Input() userData: UserData;
  @Input() editMode = false;

  constructor() { }

  ngOnInit() {}

  passwordsMatch(): boolean {
    return this.userData.confirmPassword === '' || this.userData.password === this.userData.confirmPassword;
  }

  emailValid(): boolean {
    return this.userData.email === '' || this.userData.email.includes('@');
  }

}
