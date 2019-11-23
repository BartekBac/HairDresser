import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { VisitStatusPipe } from 'src/app/shared/pipes/visit-status.pipe';
import { Functions } from 'src/app/shared/constants/Functions';
import { Time } from 'src/app/shared/models/Time';
import { Schedule } from 'src/app/shared/models/Schedule';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';

@Component({
  selector: 'app-worker-calendar',
  templateUrl: './worker-calendar.component.html',
  styleUrls: ['./worker-calendar.component.css']
})
export class WorkerCalendarComponent implements OnInit {

  @Input() visits: Visit[] = [];
  @Input() workerSchedule: Schedule;
  events: any[] = [];
  options: any;

  constructor(
    private visitStatusPipe: VisitStatusPipe
  ) {}

  ngOnInit() {
    this.visits.forEach(v => {
        this.events.push({
          title: this.visitStatusPipe.transform(v.status),
          start: v.term,
          end: new Date(new Date(v.term).getTime() + (1000 * 60 * v.totalTime)),
          color: Functions.getVisitBackgroundColor(v),
          textColor: Functions.getVisitTextColor(v)
        });
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
        left: 'prev,today,next',
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
      eventConstraint: 'businessHours'
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

}
