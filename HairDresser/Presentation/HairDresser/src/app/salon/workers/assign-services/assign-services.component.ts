import { Component, OnInit, Input } from '@angular/core';
import { Service } from 'src/app/shared/models/Service';

@Component({
  selector: 'app-assign-services',
  templateUrl: './assign-services.component.html',
  styleUrls: ['./assign-services.component.css']
})
export class AssignServicesComponent implements OnInit {

  @Input() salonServices: Service[];
  @Input() workerServices: Service[];

  constructor() { }

  ngOnInit() {
    if (this.workerServices === null) {
      this.workerServices = [];
    }
  }

  saveChanges() {
    console.log(this.workerServices);
  }

}
