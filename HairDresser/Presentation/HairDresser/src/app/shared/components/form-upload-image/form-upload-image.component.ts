import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { MessageService, FileUpload } from 'primeng/primeng';

@Component({
  selector: 'app-form-upload-image',
  templateUrl: './form-upload-image.component.html',
  styleUrls: ['./form-upload-image.component.css']
})
export class FormUploadImageComponent implements OnInit {

  @Input() imgWidth = 300;
  @Input() imageSrc: any = null;
  @Output() imageUploaded = new EventEmitter<any>();
  @ViewChild('uploadControl', null) uploadControl: FileUpload;

  constructor(private toastService: MessageService) { }

  ngOnInit() {}

  onUpload(event) {
    let file: File;
    file = event.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    const self = this;
    reader.onload = function () {
        self.imageSrc = reader.result;
        console.log(self.imageSrc);
        self.imageUploaded.emit(reader.result);
    };
    console.log(self.imageSrc);
    this.imageUploaded.emit(this.imageSrc);
    this.toastService.add({severity: 'info', summary: 'Image Uploaded',
     detail: 'Name: ' + file.name + '\nSize: ' + (file.size / 1000) + ' KB', life: 5000 });
    this.uploadControl.clear();
  }

  onSelect(event) {
    console.log(event);
  }

}
