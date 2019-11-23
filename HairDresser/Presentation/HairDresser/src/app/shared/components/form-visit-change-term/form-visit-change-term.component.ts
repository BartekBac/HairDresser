import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Visit } from '../../models/Visit';
import { WorkerService } from '../../services/worker.service';
import { VisitStatus } from '../../enums/VisitStatus';
import { MessageService } from 'primeng/primeng';
import { VisitService } from '../../services/visit.service';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-form-visit-change-term',
  templateUrl: './form-visit-change-term.component.html',
  styleUrls: ['./form-visit-change-term.component.css']
})
export class FormVisitChangeTermComponent implements OnInit {

  @Input() visit: Visit;
  @Input() isClient = true;
  @Input() isOpened = false;
  @Output() closeDialog = new EventEmitter<boolean>();
  @Output() visitUpdated = new EventEmitter<Visit>();

  calendarLoadedFlag = false;
  newTerm: Date = null;
  workerActiveVisitsEvents: any[] = [];
  workerSchedule: Schedule;

  constructor(
    private workerService: WorkerService,
    private toastService: MessageService,
    private visitService: VisitService
  ) { }

  ngOnInit() {
    this.getEvents();
  }

  getEvents() {
    this.workerService.getWorkerActiveVisits(this.visit.workerId).subscribe(
      res => {
        this.workerActiveVisitsEvents = [];
        res.forEach(v => {
          if(v.id !== this.visit.id) {
            this.workerActiveVisitsEvents.push({
              title: v.status === VisitStatus.Accepted ? 'Confirmed' : 'Pending',
              start: v.term,
              end: new Date(new Date(v.term).getTime() + (1000 * 60 * v.totalTime)),
              color: v.status === VisitStatus.Accepted ? '#ff5555' : '#ffff55',
              textColor: 'black'
            });
          }
        });
        this.workerService.getWorkerSchedule(this.visit.workerId).subscribe(
          resSchedule => {
            this.workerSchedule = resSchedule;
            this.calendarLoadedFlag = true;
          },
          err => {
            this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
            console.log(err);
          }
        );
      },
      err => {
        this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
        console.log(err);
      }
    );
  }

  setVisitDate(date: Date) {
    this.newTerm = date;
  }

  confirmChange() {
    if(this.newTerm != null) {
      this.visitService.changeVisitTerm(this.visit.id, !this.isClient, this.newTerm).subscribe(
        res => {
          this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Visit change term request sent.'});
          this.visitUpdated.emit(res);
          this.closeDialog.emit(true);
        },
        err => {
          this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
          console.log(err);
        }
      );
    } else {
      this.toastService.add({severity: 'error', summary: 'Action failed', detail: 'New date not selected.'});
    }
  }

  rejectChange() {
    this.closeDialog.emit(true);
  }

}
