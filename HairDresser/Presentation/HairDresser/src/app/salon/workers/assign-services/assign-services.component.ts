import { Component, OnInit, Input } from '@angular/core';
import { Service } from 'src/app/shared/models/Service';
import { WorkerService } from 'src/app/shared/services/worker.service';
import { MessageService } from 'primeng/primeng';
import { Functions } from 'src/app/shared/constants/Functions';

@Component({
  selector: 'app-assign-services',
  templateUrl: './assign-services.component.html',
  styleUrls: ['./assign-services.component.css']
})
export class AssignServicesComponent implements OnInit {

  @Input() salonServices: Service[];
  @Input() workerServices: Service[];
  @Input() workerId = '';

  salonServicesCopy: Service[];

  constructor(
    private workerService: WorkerService,
    private toastService: MessageService) { }

  ngOnInit() {
    if (this.workerServices === null) {
      this.workerServices = [];
    }
    this.refreshSalonServices();
  }

  refreshSalonServices() {
    this.salonServicesCopy = Functions.copyObject(this.salonServices);
    this.salonServicesCopy = this.salonServicesCopy.filter(ss => !this.workerServices.find(s => s.id === ss.id));
  }

  saveChanges() {
    this.workerService.assignWorkerServices(this.workerId, this.workerServices).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: "Worker's services assignments changed."});
      },
      err => this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error})
    );
  }

}
