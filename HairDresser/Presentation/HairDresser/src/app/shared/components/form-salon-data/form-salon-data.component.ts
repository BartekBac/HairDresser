import { Component, OnInit, Input } from '@angular/core';
import { SelectItem } from 'primeng/primeng';
import { SalonData } from '../../models/SalonData';

@Component({
  selector: 'app-form-salon-data',
  templateUrl: './form-salon-data.component.html',
  styleUrls: ['./form-salon-data.component.css']
})
export class FormSalonDataComponent implements OnInit {

  @Input() salon: SalonData;

  salonTypes: SelectItem[] = [
    {label: 'Unisex', value: 0},
    {label: 'Female', value: 1},
    {label: 'Male', value: 2}
  ];

  constructor() { }

  ngOnInit() {
  }

}
