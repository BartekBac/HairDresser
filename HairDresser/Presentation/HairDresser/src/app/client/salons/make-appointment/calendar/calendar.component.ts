import { Component, OnInit, Input } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import { Worker } from 'src/app/shared/models/Worker';
import { Day } from 'src/app/shared/models/Day';
import { strictEqual } from 'assert';
import { Time } from 'src/app/shared/models/Time';
import { Functions } from 'src/app/shared/constants/Functions';

@Component({
  selector: 'app-make-appointment-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  @Input() worker: Worker = null;
  @Input() visitDuration: number;

  events: any[] = [];
  options: any;

  constructor() { }

  ngOnInit() {
    const workerBusinessHours = [
      {
        daysOfWeek: [ 1 ],
        startTime: Functions.dayToString(this.worker.schedule.monday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.monday, 'end')
      },
      {
        daysOfWeek: [ 2 ],
        startTime: Functions.dayToString(this.worker.schedule.tuesday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.tuesday, 'end')
      },
      {
        daysOfWeek: [ 3 ],
        startTime: Functions.dayToString(this.worker.schedule.wednesday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.wednesday, 'end')
      },
      {
        daysOfWeek: [ 4 ],
        startTime: Functions.dayToString(this.worker.schedule.thursday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.thursday, 'end')
      },
      {
        daysOfWeek: [ 5 ],
        startTime: Functions.dayToString(this.worker.schedule.friday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.friday, 'end')
      },
      {
        daysOfWeek: [ 6 ],
        startTime: Functions.dayToString(this.worker.schedule.saturday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.saturday, 'end')
      },
      {
        daysOfWeek: [ 7 ],
        startTime: Functions.dayToString(this.worker.schedule.sunday, 'begin'),
        endTime: Functions.dayToString(this.worker.schedule.sunday, 'end')
      }
    ];
    /*console.log(this.getMinTime().hour+':'+this.getMinTime().minute);
    console.log(this.getMaxTime().hour+':'+this.getMaxTime().minute);*/
    console.log(Functions.dayToString(this.worker.schedule.monday, 'end'));
    this.options = {
      plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
      header: {
        left: 'prev,next',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay'
      },
      slotLabelFormat: {
        hour: 'numeric',
        minute: '2-digit',
        hour12: false
      },
      slotDuration: '00:15:00',
      allDaySlot: false,
      timeZone: 'local',
      locale: 'en',
      firstDay: 1,
      minTime: Functions.timeToString(this.getMinTime()),
      maxTime: Functions.timeToString(this.getMaxTime()),
      navLinks: true,
      businessHours: workerBusinessHours,
      views: {
        timeGridDay: {
          selectable: true,
          /*selectMirror: true,*/
          selectOverlap: false,
          constraint: workerBusinessHours
        }
      },
      editable: true
    };
  }



  private getMinTime(): Time {
    let minTime = new Time();
    minTime.hour = 24; minTime.minute = 59;
    minTime = Functions.compareTime(minTime, this.worker.schedule.monday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.worker.schedule.tuesday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.worker.schedule.wednesday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.worker.schedule.thursday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.worker.schedule.friday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.worker.schedule.saturday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.worker.schedule.sunday.begin, 'less');
    if (minTime.hour > 0) {minTime.hour -= 1;}
    return minTime;
  }

  private getMaxTime(): Time {
    let maxTime = new Time();
    maxTime.hour = 0; maxTime.minute = 0;
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.monday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.tuesday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.wednesday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.thursday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.friday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.saturday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.worker.schedule.sunday.end, 'greater');
    if (maxTime.hour < 24) {maxTime.hour += 1;}
    return maxTime;
  }

}
