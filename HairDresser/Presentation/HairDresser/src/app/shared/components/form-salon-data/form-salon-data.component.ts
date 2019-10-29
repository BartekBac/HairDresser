import { Component, OnInit, Input } from '@angular/core';
import { SelectItem } from 'primeng/primeng';
import { SalonData } from '../../models/SalonData';
import { SalonType } from '../../enums/SalonType';

@Component({
  selector: 'app-form-salon-data',
  templateUrl: './form-salon-data.component.html',
  styleUrls: ['./form-salon-data.component.css']
})
export class FormSalonDataComponent implements OnInit {

  @Input() salon: SalonData;

  salonTypes: SelectItem[] = [
    {label: 'Unisex', value: SalonType.Unisex},
    {label: 'Female', value: SalonType.Female},
    {label: 'Male', value: SalonType.Male}
  ];

  constructor() { }

  ngOnInit() {
  }

}
