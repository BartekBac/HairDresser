import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { SelectItem } from 'primeng/primeng';
import { SalonData } from '../../models/SalonData';
import { SalonType } from '../../enums/SalonType';
import { FormMapComponent } from '../form-map/form-map.component';

@Component({
  selector: 'app-form-salon-data',
  templateUrl: './form-salon-data.component.html',
  styleUrls: ['./form-salon-data.component.css']
})
export class FormSalonDataComponent implements OnInit {

  @ViewChild(FormMapComponent, null) formMapComponent: FormMapComponent;
  @Input() salon: SalonData;

  displaySetLocation = false;
  private newLocation: Location;

  salonTypes: SelectItem[] = [
    {label: 'Unisex', value: SalonType.Unisex},
    {label: 'Female', value: SalonType.Female},
    {label: 'Male', value: SalonType.Male}
  ];

  constructor() { }

  ngOnInit() {}

  showSetLocation() {
    this.displaySetLocation = true;
    // this.newLocation = this.salon.location;
    setTimeout(() => this.formMapComponent.initMap(), 100);
  }

  resetLocation() {
    this.displaySetLocation = false;
    // this.newLocation = this.salon.location;
  }

  onSelectedLocation(location: Location) {
    this.newLocation = location;
  }

  saveLocation() {
    console.log('Location saved.');
    console.log(this.newLocation);
    // this.salon.location = this.newLocation
  }

}
