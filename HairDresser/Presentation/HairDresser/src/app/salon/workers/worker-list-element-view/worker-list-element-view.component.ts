import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';
import { WorkerService } from 'src/app/shared/services/worker.service';
import { MessageService, ConfirmationService } from 'primeng/primeng';
import { UploadImage } from 'src/app/shared/models/UploadImage';
import { Service } from 'src/app/shared/models/Service';
import { AssignServicesComponent } from '../assign-services/assign-services.component';

@Component({
  selector: 'app-worker-list-element-view',
  templateUrl: './worker-list-element-view.component.html',
  styleUrls: ['./worker-list-element-view.component.css']
})
export class WorkerListElementViewComponent implements OnInit {

  @ViewChild(AssignServicesComponent, null) assignServicesComponent: AssignServicesComponent;
  @Input() worker: Worker;
  @Input() salonServices: Service[];
  @Output() deletedWorker = new EventEmitter<Worker>();

  uploadedImageSource: string;
  displayEditImage = false;
  displayEdit = false;
  displayAssignServices = false;
  displayOpinionsDialog = false;

  constructor(
    private workerService: WorkerService,
    private toastService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {}

  showEditImage() {
    this.displayEditImage = true;
  }

  showEdit() {
    this.displayEdit = true;
  }

  showAssignServices() {
    this.displayAssignServices = true;
    this.assignServicesComponent.refreshSalonServices();
  }

  onImageUpload(imageSource: any) {
    this.uploadedImageSource = imageSource;
  }

 saveImage() {
    const uploadImage: UploadImage = {
      imageSource: this.uploadedImageSource
    };
    this.workerService.uploadImage(this.worker.id, uploadImage).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Image saved to database', detail: ''});
        this.worker.imageSource = this.uploadedImageSource;
      },
      err => this.toastService.add({severity: 'error', summary: 'Cannot save image to database', detail: err.error})
    );
  }

  showDeleteDialog() {
    this.confirmationService.confirm({
        message: 'Are you sure that you want to delete ' + this.worker.firstName + ' ' + this.worker.lastName + ' worker?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        blockScroll: false,
        accept: () => {
          this.workerService.deleteWorker(this.worker.id).subscribe(
            res => {
              this.toastService.add({severity: 'success', summary: 'Action succeeded',
               detail: 'Worker ' + this.worker.firstName + ' ' + this.worker.lastName + ' deleted.'});
              this.deletedWorker.emit(this.worker);
            },
            err => this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error})
          );
        }
    });
  }

  showOpinionsDialog() {
    this.displayOpinionsDialog = true;
  }

}
