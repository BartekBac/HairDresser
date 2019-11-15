import { Component, OnInit, Input } from '@angular/core';
import { Service } from '../../models/Service';

@Component({
  selector: 'app-view-services-table',
  templateUrl: './view-services-table.component.html',
  styleUrls: ['./view-services-table.component.css']
})
export class ViewServicesTableComponent implements OnInit {

  @Input() services: Service[];

  constructor() { }

  ngOnInit() {
  }

}
