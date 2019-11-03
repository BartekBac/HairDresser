import { Component, OnInit, Input } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';
import { UploadImage } from 'src/app/shared/models/UploadImage';
import { WorkerService } from 'src/app/shared/services/worker.service';
import { MessageService } from 'primeng/primeng';
import { Service } from 'src/app/shared/models/Service';

@Component({
  selector: 'app-worker-list',
  templateUrl: './worker-list.component.html',
  styleUrls: ['./worker-list.component.css']
})
export class WorkerListComponent implements OnInit {

  @Input() workers: Worker[] = [];
  @Input() salonServices: Service[] = [];

  constructor() { }

  ngOnInit() {
  }

}
