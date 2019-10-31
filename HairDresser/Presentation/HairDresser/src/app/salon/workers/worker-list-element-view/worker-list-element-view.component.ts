import { Component, OnInit, Input } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';
import { WorkerService } from 'src/app/shared/services/worker.service';
import { MessageService } from 'primeng/primeng';
import { UploadImage } from 'src/app/shared/models/UploadImage';

@Component({
  selector: 'app-worker-list-element-view',
  templateUrl: './worker-list-element-view.component.html',
  styleUrls: ['./worker-list-element-view.component.css']
})
export class WorkerListElementViewComponent implements OnInit {

  @Input() worker: Worker;

  uploadedImageSource: string;
  displayEditImage = false;
  displayEdit = false;

  constructor(
    private workerService: WorkerService,
    private toastService: MessageService) { }

  ngOnInit() {
  }

  showEditImage() {
    this.displayEditImage = true;
  }

  showEdit() {
    this.displayEdit = true;
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

}
