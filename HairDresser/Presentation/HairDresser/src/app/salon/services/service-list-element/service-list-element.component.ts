import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Service } from 'src/app/shared/models/Service';
import { ConfirmationService, MessageService } from 'primeng/primeng';
import { ServiceService } from 'src/app/shared/services/service.service';

@Component({
  selector: 'app-service-list-element',
  templateUrl: './service-list-element.component.html',
  styleUrls: ['./service-list-element.component.css']
})
export class ServiceListElementComponent implements OnInit {

  @Input() service: Service;
  @Output() deletedService = new EventEmitter<Service>();

  displayEditService = false;

  constructor(
    private confirmationService: ConfirmationService,
    private toastService: MessageService,
    private serviceService: ServiceService) { }

  ngOnInit() {
  }

  showEditServiceDialog() {
    this.displayEditService = true;
  }

  showDeleteServiceDialog() {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to delete ' + this.service.name + ' service?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        blockScroll: false,
        accept: () => {
          this.serviceService.deleteService(this.service.id).subscribe(
            res => {
              this.toastService.add({severity: 'success', summary: 'Action succeeded',
               detail: 'Service ' + this.service.name + ' deleted.'});
              this.deletedService.emit(this.service);
            },
            err => this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error})
          );
        }
    });
  }

}
