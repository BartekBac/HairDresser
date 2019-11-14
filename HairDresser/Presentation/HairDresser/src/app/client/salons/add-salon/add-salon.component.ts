import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { Constants } from 'src/app/shared/constants/Constants';
import { Salon } from 'src/app/shared/models/Salon';
import { SelectItem } from 'primeng/primeng';
import { AuthService } from 'src/app/authentication/services/auth.service';

@Component({
  selector: 'app-add-salon',
  templateUrl: './add-salon.component.html',
  styleUrls: ['./add-salon.component.css']
})
export class AddSalonComponent implements OnInit {

  salons: Salon[] = [];
  userId: string = null;

  sortOptions: SelectItem[] = [
    {label: 'Newest First', value: '!year'},
    {label: 'Oldest First', value: 'year'},
    {label: 'Brand', value: 'brand'}
  ];

  sortKey: string;

  sortField: string;

  sortOrder: number;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.authService.showNavbar();
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.salons = this.route.snapshot.data.salons;
    console.log(this.salons);
  }

  onSortChange(event) {
    const value = event.value;

    if (value.indexOf('!') === 0) {
        this.sortOrder = -1;
        this.sortField = value.substring(1, value.length);
    } else {
        this.sortOrder = 1;
        this.sortField = value;
    }
}

}
