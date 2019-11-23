import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { VisitStatus } from 'src/app/shared/enums/VisitStatus';
import { MessageService, ConfirmationService } from 'primeng/primeng';
import { VisitService } from 'src/app/shared/services/visit.service';
import { Functions } from 'src/app/shared/constants/Functions';

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
  displayChangeVisitTermDialog = false;

  constructor(
    private toastService: MessageService,
    private visitService: VisitService,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit() {
    this.resetProperties();
  }

  private resetProperties() {
    this.date = new Date(this.visit.term);
    this.backgroundColor = Functions.getVisitBackgroundColor(this.visit);
    this.textColor = Functions.getVisitTextColor(this.visit);
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
    if (this.isClient) {
      return this.date > now && this.visit.status === VisitStatus.WorkerChangeRequested;
    } else {
      return this.date > now && (this.visit.status === VisitStatus.Pending || this.visit.status === VisitStatus.ClientChangeRequested);
    }
  }

  showRejectedButton() {
    const now = new Date();
    return (this.date > now && this.visit.status !== VisitStatus.Rejected);
  }

  showChangeTermButton() {
    const now = new Date();
    return (this.date > now && this.visit.status !== VisitStatus.Rejected);
  }

  showOpinionButton() {
    const now = new Date();
    if (this.date < now && this.isClient) {
      return !this.visit.opinionSent;
    } else {
      return false;
    }
  }

  confirmVisit() {
    this.visitService.confirmVisit(this.visit.id).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Visit confirmed.'});
        this.visit.status = res.status;
        this.visit.info = res.info;
        this.resetProperties();
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
            this.resetProperties();
          },
          err => {
            this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});
            console.log(err);
          }
        );
      }
    });
  }

  showChangeVisitTermDialog() {
    this.displayChangeVisitTermDialog = true;
  }

  onCloseChangeVisitTermDialog(close: boolean) {
    this.displayChangeVisitTermDialog = !close;
  }

  onVisitUpdated(updatedVisit: Visit) {
    this.visit.status = updatedVisit.status;
    this.visit.info = updatedVisit.info;
    this.visit.term = updatedVisit.term;
    this.resetProperties();
  }

  public showOpinionDialog() {
    console.log('Opinion dialog opened');
  }

}
