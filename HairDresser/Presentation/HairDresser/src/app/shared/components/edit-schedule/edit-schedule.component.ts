import { Component, OnInit, Input } from '@angular/core';
import { Schedule } from '../../models/Schedule';
import { Day } from '../../models/Day';

@Component({
  selector: 'app-edit-schedule',
  templateUrl: './edit-schedule.component.html',
  styleUrls: ['./edit-schedule.component.css']
})
export class EditScheduleComponent implements OnInit {

  @Input() schedule: Schedule;

  constructor() { }

  ngOnInit() {}

}
