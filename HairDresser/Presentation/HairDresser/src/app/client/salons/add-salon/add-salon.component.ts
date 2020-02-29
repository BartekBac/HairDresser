import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { Constants } from 'src/app/shared/constants/Constants';
import { Salon } from 'src/app/shared/models/Salon';
import { AuthService } from 'src/app/authentication/services/auth.service';
import { MenuItem } from 'primeng/primeng';

@Component({
  selector: 'app-add-salon',
  templateUrl: './add-salon.component.html',
  styleUrls: ['./add-salon.component.css']
})
export class AddSalonComponent implements OnInit {

  salons: Salon[] = [];
  userId: string = null;

  tabMenuItems: MenuItem[] = [
    {label: 'List', icon: 'pi pi-list'},
    {label: 'Map', icon: 'pi pi-globe'}
  ];

  activeMenuItem: MenuItem;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.authService.showNavbar();
    this.toggleMenu(0);
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.salons = this.route.snapshot.data.salons;
    console.log(this.salons);
  }

  toggleMenu(index: number) {
    this.activeMenuItem = this.tabMenuItems[index];
  }

}
