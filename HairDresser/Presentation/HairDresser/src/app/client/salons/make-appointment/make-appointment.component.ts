import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import { Worker } from 'src/app/shared/models/Worker';
import { Service } from 'src/app/shared/models/Service';
import { VisitCreation } from '../../models/VisitCreation';
import { MessageService } from 'primeng/primeng';
import { VisitService } from 'src/app/shared/services/visit.service';
import { WorkerService } from 'src/app/shared/services/worker.service';
import { VisitStatus } from 'src/app/shared/enums/VisitStatus';
import { Visit } from 'src/app/shared/models/Visit';

@Component({
  selector: 'app-make-appointment',
  templateUrl: './make-appointment.component.html',
  styleUrls: ['./make-appointment.component.css']
})
export class MakeAppointmentComponent implements OnInit {

  @Input() salons: Salon[] = [];
  @Input() selectedSalon: Salon;
  @Input() userId: string;
  @Output() closeDialog = new EventEmitter<boolean>();
  @Output() addedVisit = new EventEmitter<Visit>();

  selectedWorker: Worker = null;
  selectedServices: Service[] = [];
  workerActiveVisitsEvents: any[] = [];
  selectedServicesString = '';
  selectedServicesTotalPrice = 0;
  selectedServicesTotalTime = 0;
  visitDate: Date = null;
  selectWorkerTab = true;
  selectServicesTab = false;
  selectSalonTab = false;
  showCalendarFlag = false;
  calendarLoadedFlag = false;

  constructor(
    private toastService: MessageService,
    private visitService: VisitService,
    private workerService: WorkerService
  ) { }

  ngOnInit() {}

  onSalonSelected(selectedSalon: Salon) {
    this.selectedSalon = selectedSalon;
    this.selectedWorker = null;
    this.selectedServices = [];
    this.selectedServicesString = '';
    this.selectedServicesTotalPrice = 0;
    this.selectedServicesTotalTime = 0;
    this.selectSalonTab = false;
    this.selectWorkerTab = true;
    this.selectServicesTab = false;
    this.calendarLoadedFlag = false;
  }

  onWorkerSelected(selectedWorker: Worker) {
    this.selectedWorker = selectedWorker;
    this.selectedServices = [];
    this.selectedServicesString = '';
    this.selectedServicesTotalPrice = 0;
    this.selectedServicesTotalTime = 0;
    this.selectSalonTab = false;
    this.selectWorkerTab = false;
    this.selectServicesTab = true;
    this.calendarLoadedFlag = false;
  }

  onServicesSelect() {
    this.selectedServicesTotalPrice = 0;
    this.selectedServicesTotalTime = 0;
    this.selectedServicesString = '';
    this.selectedServices.forEach(s => {
      this.selectedServicesString += s.name + ', ';
      this.selectedServicesTotalPrice += s.price;
      this.selectedServicesTotalTime += s.time;
    });
    this.selectedServicesString = this.selectedServicesString.slice(0, this.selectedServicesString.length - 2);
  }

  onSalonAccordionTabHeaderClick() {
    this.selectSalonTab = true;
    this.selectWorkerTab = false;
    this.selectServicesTab = false;
  }

  onWorkerAccordionTabHeaderClick() {
    this.selectSalonTab = false;
    this.selectWorkerTab = true;
    this.selectServicesTab = false;
  }

  showCalendar() {
    this.showCalendarFlag = true;
    if(this.calendarLoadedFlag === false) {
      this.workerService.getWorkerActiveVisits(this.selectedWorker.id).subscribe(
        res => {
          this.workerActiveVisitsEvents = [];
          res.forEach(v => {
              this.workerActiveVisitsEvents.push({
                title: v.status === VisitStatus.Accepted ? 'Accepted' : 'Pending',
                start: v.term,
                end: new Date(new Date(v.term).getTime() + (1000 * 60 * v.totalTime)),
                color: v.status === VisitStatus.Accepted ? 'lightcoral' : '#ffff55',
                textColor: 'black'
              });
            }
          );
          this.calendarLoadedFlag = true;
        },
        err => {
          this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
          this.showCalendarFlag = false;
          console.log(err);
        }
      );
    }
  }

  showVisitDetails() {
    this.showCalendarFlag = false;
    this.visitDate = null;
  }

  setVisitDate(date: Date) {
    this.visitDate = date;
  }

  confirmVisit() {
    const newVisit = new VisitCreation();
    newVisit.clientId = this.userId;
    if (!this.selectedWorker) {
      this.toastService.add({severity: 'error', summary: 'Making appointment failed', detail: 'Worker not selected.'})
      return;
    }
    newVisit.workerId = this.selectedWorker.id;
    if (this.selectedServices.length === 0) {
      this.toastService.add({severity: 'error', summary: 'Making appointment failed', detail: 'Services not selected.'})
      return;
    }
    newVisit.serviceIds = [];
    this.selectedServices.forEach(s => newVisit.serviceIds.push(s.id));
    newVisit.totalPrice = this.selectedServicesTotalPrice;
    newVisit.totalTime = this.selectedServicesTotalTime;
    if (!this.visitDate) {
      this.toastService.add({severity: 'error', summary: 'Making appointment failed', detail: 'Date not selected.'})
      return;
    }
    const minDate = new Date(Date.now() + (1000 * 60 * 30));
    if (this.visitDate < minDate) {
      this.toastService.add({severity: 'error', summary: 'Making appointment failed',
       detail: 'Appointment should be done at least 30 minutes before visit.'})
      return;
    }
    newVisit.term = this.visitDate;
    this.visitService.addVisit(newVisit).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Visit request has been sent.'});
        this.addedVisit.emit(res);
        this.closeDialog.emit(true);
      },
      err => {
        this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
        console.log(err);
      }
    );
  }

  rejectVisit() {
    this.closeDialog.emit(true);
  }

}
