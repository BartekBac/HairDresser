import { Component, OnInit, Input } from '@angular/core';
import { Worker } from 'src/app/shared/models/Worker';

@Component({
  selector: 'app-client-salon-workers-list-element',
  templateUrl: './workers-list-element.component.html',
  styleUrls: ['./workers-list-element.component.css']
})
export class WorkersListElementComponent implements OnInit {

  @Input() worker: Worker;
  @Input() isSelected = false;

  constructor() { }

  ngOnInit() {
  }

}
