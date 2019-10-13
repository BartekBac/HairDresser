import { Component, OnInit, Input } from '@angular/core';
import { UserData } from '../../models/UserData';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {

  @Input() userData: UserData;

  constructor() { }

  ngOnInit() {}

  passwordsMatch(): boolean {
    return this.userData.confirmPassword === '' || this.userData.password === this.userData.confirmPassword;
  }

  emailValid(): boolean {
    return this.userData.email === '' || this.userData.email.includes('@');
  }

}
