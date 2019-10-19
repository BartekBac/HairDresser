import { Component, OnInit, Input } from '@angular/core';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-form-schedule',
  templateUrl: './form-schedule.component.html',
  styleUrls: ['./form-schedule.component.css']
})
export class FormScheduleComponent implements OnInit {

  @Input() schedule: Schedule;

  constructor() { }

  ngOnInit() {
  }

}
