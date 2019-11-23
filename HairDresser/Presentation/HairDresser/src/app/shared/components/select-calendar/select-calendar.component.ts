import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin, { Draggable } from '@fullcalendar/interaction';
import { Time } from 'src/app/shared/models/Time';
import { Functions } from 'src/app/shared/constants/Functions';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-select-calendar',
  templateUrl: './select-calendar.component.html',
  styleUrls: ['./select-calendar.component.css']
})
export class SelectCalendarComponent implements OnInit {

  @Input() workerSchedule: Schedule = null;
  @Input() visitDuration: number;
  @Input() events: any[] = [];
  @Output() selectedVisitDate = new EventEmitter<Date>();

  visitDate: Date;
  myDraggable = null;
  visitMovedToCalendar = false;
  options: any;

  constructor() { }

  ngOnInit() {
    this.myDraggable = new Draggable(document.getElementById('draggable-el'), {
      eventData: {
        title: 'My visit',
        duration: {minutes: this.visitDuration},
        startEditable: true
      }
    });
    const workerBusinessHours = [
      {
        daysOfWeek: [ 1 ],
        startTime: Functions.dayToString(this.workerSchedule.monday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.monday, 'end')
      },
      {
        daysOfWeek: [ 2 ],
        startTime: Functions.dayToString(this.workerSchedule.tuesday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.tuesday, 'end')
      },
      {
        daysOfWeek: [ 3 ],
        startTime: Functions.dayToString(this.workerSchedule.wednesday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.wednesday, 'end')
      },
      {
        daysOfWeek: [ 4 ],
        startTime: Functions.dayToString(this.workerSchedule.thursday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.thursday, 'end')
      },
      {
        daysOfWeek: [ 5 ],
        startTime: Functions.dayToString(this.workerSchedule.friday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.friday, 'end')
      },
      {
        daysOfWeek: [ 6 ],
        startTime: Functions.dayToString(this.workerSchedule.saturday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.saturday, 'end')
      },
      {
        daysOfWeek: [ 7 ],
        startTime: Functions.dayToString(this.workerSchedule.sunday, 'begin'),
        endTime: Functions.dayToString(this.workerSchedule.sunday, 'end')
      }
    ];
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
      events: this.events,
      slotDuration: '00:15:00',
      allDaySlot: false,
      timeZone: 'local',
      locale: 'en',
      firstDay: 1,
      minTime: Functions.timeToString(this.getMinTime()),
      maxTime: Functions.timeToString(this.getMaxTime()),
      navLinks: true,
      businessHours: workerBusinessHours,
      selectConstraint: 'businessHours',
      views: {
        timeGridDay: {
          selectable: true,
          selectConstraint: workerBusinessHours
        }
      },
      editable: false,
      eventOverlap: false,
      eventConstraint: 'businessHours',
      eventReceive: (info) => {
        this.visitMovedToCalendar = true;
        this.setVisitDate(info.event.start.toISOString());
      },
      eventDrop: (info) => this.setVisitDate(info.event.start.toISOString())
    };
  }

  private getMinTime(): Time {
    let minTime = new Time();
    minTime.hour = 24; minTime.minute = 59;
    minTime = Functions.compareTime(minTime, this.workerSchedule.monday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.workerSchedule.tuesday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.workerSchedule.wednesday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.workerSchedule.thursday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.workerSchedule.friday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.workerSchedule.saturday.begin, 'less');
    minTime = Functions.compareTime(minTime, this.workerSchedule.sunday.begin, 'less');
    if (minTime.hour > 0) {minTime.hour -= 1;}
    return minTime;
  }

  private getMaxTime(): Time {
    let maxTime = new Time();
    maxTime.hour = 0; maxTime.minute = 0;
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.monday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.tuesday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.wednesday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.thursday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.friday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.saturday.end, 'greater');
    maxTime = Functions.compareTime(maxTime, this.workerSchedule.sunday.end, 'greater');
    if (maxTime.hour < 24) {maxTime.hour += 1;}
    return maxTime;
  }

  private setVisitDate(date: any) {
    this.visitDate = new Date(date);
    this.selectedVisitDate.emit(this.visitDate);
  }

}
