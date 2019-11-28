import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { Constants } from 'src/app/shared/constants/Constants';
import { Salon } from 'src/app/shared/models/Salon';
import { SelectItem, MessageService } from 'primeng/primeng';
import { AuthService } from 'src/app/authentication/services/auth.service';
import { ClientService } from 'src/app/shared/services/client.service';

@Component({
  selector: 'app-add-salon',
  templateUrl: './add-salon.component.html',
  styleUrls: ['./add-salon.component.css']
})
export class AddSalonComponent implements OnInit {

  salons: Salon[] = [];
  userId: string = null;

  sortOptions: SelectItem[] = [
    {label: 'Name', value: 'name'},
    {label: 'Rating', value: '!rating'},
    {label: 'Type', value: 'type'},
  ];
  sortKey: string;
  sortField: string;
  sortOrder: number;

  filterOptions: SelectItem[] = [
    {label: 'Name', value: 'name'},
    {label: 'City', value: 'address.city'},
  ];
  selectedFilterValue: string;
  selectedFilterLabel: string;
  filteredSearchValues: string[];
  searchValue: string;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private clientService: ClientService,
    private toastService: MessageService
  ) { }

  ngOnInit() {
    this.authService.showNavbar();
    const decodedToken = jwt_decode(localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN));
    this.userId = decodedToken[Constants.DECODE_TOKEN_USER_ID];
    this.salons = this.route.snapshot.data.salons;
    this.selectedFilterValue = this.filterOptions[0].value;
    this.selectedFilterLabel = this.filterOptions[0].label;
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

  onSelectFilterChange(event) {
    this.selectedFilterLabel = this.filterOptions.find(fo => fo.value === this.selectedFilterValue).label;
  }

  private unique(value, index, self) {
    return self.indexOf(value) === index;
  }

  filterSearchValues(event) {
    const query = event.query;
    if (query && query.length > 0) {
    if (this.selectedFilterValue === this.filterOptions[0].value) {
        this.filteredSearchValues = this.salons.filter(s =>
           s.name.toLowerCase().startsWith(query.toLowerCase())).map(s => s.name);
      } else if (this.selectedFilterValue === this.filterOptions[1].value) {
        this.filteredSearchValues = this.salons.filter(s =>
           s.address.city.toLowerCase().startsWith(query.toLowerCase())).map(s => s.address.city);
      }
    } else {
      if (this.selectedFilterValue === this.filterOptions[0].value) {
        this.filteredSearchValues = this.salons.map(s => s.name);
      } else if (this.selectedFilterValue === this.filterOptions[1].value) {
        this.filteredSearchValues = this.salons.map(s => s.address.city);
      }
    }
    this.filteredSearchValues = this.filteredSearchValues.filter(this.unique);
  }

  addToFavourites(salon: Salon) {
    this.clientService.addFavouriteSalon(this.userId, salon.id).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Salon added to favourites list.'});
        this.salons = this.salons.filter(s => s.id !== salon.id);
      },
      err => {this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});}
    );
  }

}
