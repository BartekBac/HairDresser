import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { Constants } from 'src/app/shared/constants/Constants';
import { Client } from 'src/app/shared/models/Client';
import { AuthService } from 'src/app/authentication/services/auth.service';
import { MenuItem } from 'primeng/primeng';
import { Salon } from 'src/app/shared/models/Salon';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  client: Client = null;
  userId: string = null;

  tabMenuItems: MenuItem[] = [
    {label: 'Salons', icon: 'pi pi-list'},
    {label: 'Visits', icon: 'pi pi-calendar'},
    {label: 'Opinions', icon: 'pi pi-comment'}
  ];

  activeMenuItem: MenuItem;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService
    ) { }

  ngOnInit() {
    this.toggleMenu(0);
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.authService.showNavbar();
    this.client = this.route.snapshot.data.client;
    console.log(this.client);
  }

  toggleMenu(index: number) {
    this.activeMenuItem = this.tabMenuItems[index];
  }

  onRemoveSalon(removedSalon: Salon) {
    this.client.favoriteSalons = this.client.favoriteSalons.filter(s => s.id !== removedSalon.id);
  }

}
