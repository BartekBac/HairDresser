import { Component, OnInit, Input } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';

@Component({
  selector: 'app-client-salon-workers-list',
  templateUrl: './workers-list.component.html',
  styleUrls: ['./workers-list.component.css']
})
export class ClientSalonWorkersListComponent implements OnInit {

  @Input() workers: Worker[];

  selectedWorker: Worker = null;

  constructor() { }

  ngOnInit() {
  }

  onWorkerSelected(selectedWorker: Worker) {
    this.selectedWorker = selectedWorker;
  }

}
