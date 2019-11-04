import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Service } from 'src/app/shared/models/Service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.css']
})
export class ServiceListComponent implements OnInit {

  @Input() services: Service[];
  @Output() deleteService = new EventEmitter<Service>();

  constructor() { }

  ngOnInit() {
  }

  onDelete(deletedService: Service) {
    this.deleteService.emit(deletedService);
  }

}
