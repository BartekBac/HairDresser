import { Component, OnInit, Input } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import { Worker } from 'src/app/shared/models/Worker';
import { Day } from 'src/app/shared/models/Day';
import { strictEqual } from 'assert';
import { Time } from 'src/app/shared/models/Time';

@Component({
  selector: 'app-make-appointment-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  @Input() worker: Worker = null;

  events: any[] = [];
  options:any = {
    plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
    timeZone: 'local',
    slotLabelFormat: {
      hour: 'numeric',
      minute: '2-digit',
      hour12: false
    },
    slotDuration: '00:15:00',
    locale: 'en',
    firstDay: 1,
    header: {
        left: 'prev,next',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay'
    },
    allDaySlot: false,
    /*businessHours: [
      {
        daysOfWeek: [ 1 ],
        startTime: this.worker.schedule.monday.isActive ?
          this.worker.schedule.monday.begin.hour+':'+this.worker.schedule.monday.begin.minute
          :
          '24:00',
        endTime: this.worker.schedule.monday.isActive ?
        this.worker.schedule.monday.end.hour+':'+this.worker.schedule.monday.end.minute
        :
        '24:00',
      },
      {
        daysOfWeek: [ 4, 5 ], // Thursday, Friday
        startTime: '10:00', // 10am
        endTime: '16:00' // 4pm
      }
    ],*/
    editable: true
  };

  constructor() { }

  ngOnInit() {
    this.options = {
      plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
      timeZone: 'local',
      slotLabelFormat: {
        hour: 'numeric',
        minute: '2-digit',
        hour12: false
      },
      slotDuration: '00:15:00',
      locale: 'en',
      firstDay: 1,
      header: {
          left: 'prev,next',
          center: 'title',
          right: 'dayGridMonth,timeGridWeek,timeGridDay'
      },
      allDaySlot: false,
      businessHours: [
        {
          daysOfWeek: [ 1 ],
          startTime: this.getTime(this.worker.schedule.monday),
          endTime: this.getTime(this.worker.schedule.monday, false),
        },
        {
          daysOfWeek: [ 4, 5 ], // Thursday, Friday
          startTime: '10:00', // 10am
          endTime: '16:00' // 4pm
        }
      ],
      editable: true
    };
  }

  private getTime(day: Day, begin = true): string {
    if (day.isActive) {
      if (begin) {
        return day.begin.hour.toString() + ':' + day.begin.minute.toString().padStart(2, '0');
      } else {
        return day.end.hour.toString() + ':' + day.end.minute.toString().padStart(2, '0');
      }
    } else {
      return '24:00';
    }
  }

  private getMinTime() {

  }

}
