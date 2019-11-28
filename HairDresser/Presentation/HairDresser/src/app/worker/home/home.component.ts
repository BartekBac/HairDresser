import { Component, OnInit } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { Constants } from 'src/app/shared/constants/Constants';
import { AuthService } from 'src/app/authentication/services/auth.service';
import { MenuItem } from 'primeng/primeng';
import { Worker } from 'src/app/shared/models/Worker';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  worker: Worker = null;
  userId: string = null;

  tabMenuItems: MenuItem[] = [
    {label: 'Visits', icon: 'pi pi-list'},
    {label: 'Calendar', icon: 'pi pi-calendar'},
    {label: 'Opinions', icon: 'pi pi-comments'}
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
    this.worker = this.route.snapshot.data.worker;
    console.log(this.worker);
  }

  toggleMenu(index: number) {
    this.activeMenuItem = this.tabMenuItems[index];
  }

}
