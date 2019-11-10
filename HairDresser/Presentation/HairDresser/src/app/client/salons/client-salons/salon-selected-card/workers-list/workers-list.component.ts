import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';

@Component({
  selector: 'app-client-salon-workers-list',
  templateUrl: './workers-list.component.html',
  styleUrls: ['./workers-list.component.css']
})
export class ClientSalonWorkersListComponent implements OnInit, OnChanges {

  @Input() workers: Worker[];

  selectedWorker: Worker = null;

  constructor() { }

  ngOnInit() {
  }

  onWorkerSelected(selectedWorker: Worker) {
    this.selectedWorker = selectedWorker;
  }

  ngOnChanges(changes: SimpleChanges) {
    this.selectedWorker = null;
  }

}
