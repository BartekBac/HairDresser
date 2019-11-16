import { Component, OnInit, Input } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import { Worker } from 'src/app/shared/models/Worker';
import { Service } from 'src/app/shared/models/Service';

@Component({
  selector: 'app-make-appointment',
  templateUrl: './make-appointment.component.html',
  styleUrls: ['./make-appointment.component.css']
})
export class MakeAppointmentComponent implements OnInit {

  @Input() salon: Salon;
  @Input() userId: string;

  selectedWorker: Worker = null;
  selectedServices: Service[] = [];
  selectedServicesString = '';
  selectedServicesTotalPrice = 0;
  selectedServicesTotalTime = 0;
  selectServicesTab = false;
  showCalendarFlag = false;
  calendarLoadedFlag = false;

  constructor() { }

  ngOnInit() {
  }

  onWorkerSelected(selectedWorker: Worker) {
    this.selectedWorker = selectedWorker;
    this.selectedServices = [];
    this.selectedServicesString = '';
    this.selectedServicesTotalPrice = 0;
    this.selectedServicesTotalTime = 0;
    this.selectServicesTab = true;

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

  onWorkerAccordionTabHeaderClick() {
    this.selectServicesTab = false;
  }

  showCalendar() {
    this.showCalendarFlag = true;
    setTimeout(() => this.calendarLoadedFlag = true, 1);
  }

}
