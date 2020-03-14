import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { SelectItem, MessageService } from 'primeng/primeng';
import { SalonData } from '../../models/SalonData';
import { SalonType } from '../../enums/SalonType';
import { FormMapComponent } from '../form-map/form-map.component';
import { Location } from '../../models/Location';

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

  constructor(private toastService: MessageService) { }

  ngOnInit() {}

  showSetLocation() {
    this.displaySetLocation = true;
    setTimeout(() => this.formMapComponent.initMap(), 100);
  }

  resetLocation() {
    this.newLocation = this.salon.location;
    this.displaySetLocation = false;
  }

  onSelectedLocation(location: Location) {
    this.newLocation = location;
  }

  saveLocation() {
    this.salon.location = this.newLocation;
    this.displaySetLocation = false;
    this.toastService.add({severity: 'info', summary: 'Salon location defined',
      detail: 'To save the salon location, click "Save" button.'});
  }

}
