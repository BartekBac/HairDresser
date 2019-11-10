import { Component, OnInit, Input } from '@angular/core';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-view-schedule',
  templateUrl: './view-schedule.component.html',
  styleUrls: ['./view-schedule.component.css']
})
export class ViewScheduleComponent implements OnInit {

  @Input() schedule: Schedule;

  constructor() { }

  ngOnInit() {
  }

}
