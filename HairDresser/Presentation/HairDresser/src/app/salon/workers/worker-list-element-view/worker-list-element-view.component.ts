import { Component, OnInit, Input } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';

@Component({
  selector: 'app-worker-list-element-view',
  templateUrl: './worker-list-element-view.component.html',
  styleUrls: ['./worker-list-element-view.component.css']
})
export class WorkerListElementViewComponent implements OnInit {

  @Input() worker: Worker;

  constructor() { }

  ngOnInit() {
  }

}
