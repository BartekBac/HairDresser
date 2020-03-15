import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { SelectItem, MessageService } from 'primeng/primeng';
import { SalonData } from '../../models/SalonData';
import { SalonType } from '../../enums/SalonType';
import { FormMapComponent } from '../form-map/form-map.component';
import { Location } from '../../models/Location';
import { GeocodingService } from '../../services/geocoding.service';
import { Functions } from '../../constants/Functions';
import { Address } from '../../models/Address';

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

  constructor(private toastService: MessageService,
              private geocodingService: GeocodingService) { }

  ngOnInit() {}

  showSetLocation() {
    this.displaySetLocation = true;
    if (Functions.isNotLocationSet(this.salon.location)) {
      this.geocodingService.search(Functions.concatAddressToSearchString(this.salon.address))
      .subscribe(res => {
        if (res.length > 0) {
          this.toastService.add({severity: 'info', summary: 'Location automatically found',
            detail: 'If you want to save it as location of your salon, apply changes and click "Save" button.'});
          this.salon.location = res[0];
        } else {
          this.toastService.add({severity: 'info', life: 10000, summary: 'Location not found',
          detail: 'Location cannot be automatically defined based on the provided address.' +
           'Set the location manually, apply changes and click "Save" button to commit changes.'});
        }
      }, err => {
        this.toastService.add({severity: 'info', life: 10000, summary: 'Location not found',
        detail: 'Location cannot be automatically defined based on the provided address.' +
         'Set the location manually, apply changes and click "Save" button to commit changes.'});
        console.log(err);
      }, /* complete */ () => {
        setTimeout(() => this.formMapComponent.initMap(), 100);
      });
    } else {
      setTimeout(() => this.formMapComponent.initMap(), 100);
    }
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
