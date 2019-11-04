import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';
import { Service } from 'src/app/shared/models/Service';

@Component({
  selector: 'app-worker-list',
  templateUrl: './worker-list.component.html',
  styleUrls: ['./worker-list.component.css']
})
export class WorkerListComponent implements OnInit {

  @Input() workers: Worker[] = [];
  @Input() salonServices: Service[] = [];
  @Output() deleteWorker = new EventEmitter<Worker>();

  constructor() { }

  ngOnInit() {
  }

  onDelete(deletedWorker: Worker) {
    this.deleteWorker.emit(deletedWorker);
  }

}
