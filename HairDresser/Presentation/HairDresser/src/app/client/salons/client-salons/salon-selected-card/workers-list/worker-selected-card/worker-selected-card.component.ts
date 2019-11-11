import { Component, OnInit, Input } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';
import { OverlayPanel } from 'primeng/primeng';
import * as $ from 'jquery';

@Component({
  selector: 'app-client-salon-worker-selected-card',
  templateUrl: './worker-selected-card.component.html',
  styleUrls: ['./worker-selected-card.component.css']
})
export class WorkerSelectedCardComponent implements OnInit {

  @Input() worker: Worker;

  constructor() { }

  ngOnInit() {
  }

}
