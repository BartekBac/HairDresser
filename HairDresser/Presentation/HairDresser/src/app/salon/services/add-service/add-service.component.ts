import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ServiceCreation } from '../../models/ServiceCreation';
import { Service } from 'src/app/shared/models/Service';
import { ServiceService } from 'src/app/shared/services/service.service';
import { MessageService } from 'primeng/primeng';
import { ValidationMessage } from 'src/app/shared/models/ValidationMessage';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.css']
})
export class AddServiceComponent implements OnInit {

  @Input() salonId: string;
  @Input() editMode = false;
  @Input() editService: Service;
  @Output() addedService = new EventEmitter<Service>();

  serviceCreation: ServiceCreation = {
    name: '',
    price: null,
    time: null,
    salonId: ''
  };

  protected validationMessage: ValidationMessage = null;

  constructor(
    private serviceService: ServiceService,
    private toastService: MessageService) { }

  ngOnInit() {
    if (this.editMode) {
      this.serviceCreation.name = this.editService.name;
      this.serviceCreation.price = this.editService.price;
      this.serviceCreation.time = this.editService.time;
    } else {
      this.serviceCreation.salonId = this.salonId;
    }
  }

  dataValid(): ValidationMessage {
    let toReturn = new ValidationMessage(true, 'Data valid');
    this.serviceCreation.price = +this.serviceCreation.price;
    this.serviceCreation.time = +this.serviceCreation.time;
    if (this.serviceCreation.name === '') {
      toReturn.update(false, "Service name cannot by empty.");
    } else if (this.serviceCreation.price < 0) {
      toReturn.update(false, "Price cannot by less than zero.");
    } else if (this.serviceCreation.time <= 0) {
      toReturn.update(false, "Time duration of service should be greatee than zero.");
    }
    return toReturn;
  }

  private copyValuesToEditService() {
    this.editService.name = this.serviceCreation.name;
    this.editService.price = +this.serviceCreation.price;
    this.editService.time = +this.serviceCreation.time;
  }

  submit() {
    this.validationMessage = this.dataValid();
    if (this.validationMessage.isValid) {
      if (!this.editMode) {
        this.editService = new Service ();
        this.copyValuesToEditService();
        this.serviceService.addService(this.serviceCreation).subscribe(
          res => {
            this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'New service added to list'});
            this.addedService.emit(this.editService);
          },
          err => this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error})
        );
      } else {
        this.copyValuesToEditService();
        this.serviceService.editService(this.editService).subscribe(
          res => {
            this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Service data changed'});
          },
          err => this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error})
        );
      }
    }
  }

}
