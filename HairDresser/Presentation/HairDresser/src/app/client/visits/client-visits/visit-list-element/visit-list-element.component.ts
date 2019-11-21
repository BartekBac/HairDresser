import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { VisitStatus } from 'src/app/shared/enums/VisitStatus';
import { MessageService, ConfirmationService } from 'primeng/primeng';
import { VisitService } from 'src/app/shared/services/visit.service';

@Component({
  selector: 'app-visit-list-element',
  templateUrl: './visit-list-element.component.html',
  styleUrls: ['./visit-list-element.component.css']
})
export class VisitListElementComponent implements OnInit {

  @Input() visit: Visit;
  @Input() isClient = true;
  date: Date;
  backgroundColor: string;
  textColor: string;

  constructor(
    private toastService: MessageService,
    private visitService: VisitService,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit() {
    this.date = new Date(this.visit.term);
    this.setColors();
  }

  private setColors() {
    switch (this.visit.status) {
      case VisitStatus.Accepted: this.backgroundColor = '#55ff55'; break;
      case VisitStatus.ClientChangeRequested: this.backgroundColor = '#8888ff'; break;
      case VisitStatus.WorkerChangeRequested: this.backgroundColor = '#3333ff'; break;
      case VisitStatus.Pending: this.backgroundColor = '#ffff55'; break;
      case VisitStatus.Rejected: this.backgroundColor = '#ff5555'; break;
      default: this.backgroundColor = '#555555';
    }
    const now = new Date();
    if (this.date < now) {
      this.backgroundColor = '#555555';
    }

    if (this.backgroundColor === '#555555') {
      this.textColor = '#dedede';
    } else {
      this.textColor = '#212121';
    }
  }

  getServicesString(): string {
    let toReturn = '';
    this.visit.services.forEach(s => toReturn += s.name + ', ');
    toReturn = toReturn.slice(0, toReturn.length - 2);
    return toReturn;
  }

  copyToClipboard(item) {
    let listener = (e: ClipboardEvent) => {
        e.clipboardData.setData('text/plain', (item));
        e.preventDefault();
    };

    document.addEventListener('copy', listener);
    document.execCommand('copy');
    document.removeEventListener('copy', listener);
  }

  showConfirmButton() {
    const now = new Date();
    return this.date > now && this.visit.status === VisitStatus.WorkerChangeRequested;
  }

  showRejectedButton() {
    const now = new Date();
    return (this.date > now && this.visit.status !== VisitStatus.Rejected);
  }

  confirmVisit() {
    this.visitService.confirmVisit(this.visit.id).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Visit confirmed.'});
        this.visit.status = res.status;
        this.visit.info = res.info;
        this.setColors();
      },
      err => {
        this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
        console.log(err);
      }
    );
  }

  rejectVisit() {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to reject this visit?',
      header: 'Reject Confirmation',
      icon: 'pi pi-info-circle',
      blockScroll: false,
      accept: () => {
        this.visitService.rejectVisit(this.visit.id, !this.isClient).subscribe(
          res => {
            this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Visit rejected.'});
            this.visit.status = res.status;
            this.visit.info = res.info;
            this.setColors();
          },
          err => {
            this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
            console.log(err);
          }
        );
      }
    });
  }

  changeVisitTerm(newTerm: Date) {
    newTerm = new Date(2019, 26, 11, 12, 15);
    this.visitService.changeVisitTerm(this.visit.id, !this.isClient, newTerm).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Visit change term request sent.'});
        this.visit.status = res.status;
        this.visit.info = res.info;
        this.visit.term = res.term;
        this.setColors();
      },
      err => {
        this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
        console.log(err);
      }
    );
  }

}
