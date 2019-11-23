import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';

@Component({
  selector: 'app-worker-visits',
  templateUrl: './worker-visits.component.html',
  styleUrls: ['./worker-visits.component.css']
})
export class WorkerVisitsComponent implements OnInit {

  @Input() visits: Visit[] = [];

  constructor() { }

  ngOnInit() {
  }

}
