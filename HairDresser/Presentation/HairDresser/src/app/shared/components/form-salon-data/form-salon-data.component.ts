import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { SelectItem, MessageService, ConfirmationService } from 'primeng/primeng';
import { SalonData } from '../../models/SalonData';
import { SalonType } from '../../enums/SalonType';
import { FormMapComponent } from '../form-map/form-map.component';
import { Location } from '../../models/Location';
import { GeocodingService } from '../../services/geocoding.service';
import { Functions } from '../../constants/Functions';
import * as _ from 'lodash';

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
              private geocodingService: GeocodingService,
              private confirmationService: ConfirmationService) { }

  ngOnInit() {}

  showSetLocation() {
    this.displaySetLocation = true;
    if (!Functions.isLocationSet(this.salon.location)) {
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
        setTimeout(() => this.formMapComponent.initMap(), 100);
      }, /* complete */ () => {
        console.log('from compelte');
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
    if (!_.isEqual(this.salon.location, this.newLocation)) {
      this.salon.location = this.newLocation;
      this.toastService.add({severity: 'info', summary: 'Salon location defined',
                             detail: 'To save the salon location, click "Save" button.'});
      this.geocodingService.reverse(this.newLocation.latitude, this.newLocation.longitude)
        .subscribe(
          res => {
            if (!_.isEqual(res, this.salon.address)) {
              this.confirmationService.confirm({
                message: 'Do you want to change the address of the salon to ' +
                          res.city + ' (' + res.zipCode + '), ' +
                          res.street + ' ' + res.houseNumber + '?',
                header: 'Mismatched address detected',
                icon: 'pi pi-exclamation-triangle',
                blockScroll: false,
                accept: () => {
                  this.salon.address = res;
                  this.toastService.add({severity: 'info', summary: 'Salon location & address changed',
                    detail: 'To save changes, click "Save" button.'});
                }
            });
            }
          }
        );
    }
    this.displaySetLocation = false;
  }

}
