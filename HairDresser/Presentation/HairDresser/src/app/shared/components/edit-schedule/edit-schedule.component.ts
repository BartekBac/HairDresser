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

  protected mondayActive = true;

  constructor() { }

  ngOnInit() {
    this.schedule.monday.begin.minute = 11;
    console.log(this.schedule.monday);
  }

  changeActivity(active: boolean, day: Day) {
    console.log(this.schedule.monday);
    console.log(active);
    if (active) {
      day.begin.hour = 0;
      day.begin.minute = 0;
      day.end.hour = 23;
      day.end.minute = 59;
      console.log(this.schedule.monday);
    }
  }

  kuClick() {
    this.schedule.monday.begin.minute += 10;
  }

}
