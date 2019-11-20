import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { VisitStatus } from 'src/app/shared/enums/VisitStatus';

@Component({
  selector: 'app-visit-list-element',
  templateUrl: './visit-list-element.component.html',
  styleUrls: ['./visit-list-element.component.css']
})
export class VisitListElementComponent implements OnInit {

  @Input() visit: Visit;
  date: Date;
  backgroundColor: string;
  textColor: string;

  constructor() { }

  ngOnInit() {
    this.date = new Date(this.visit.term);
    switch (this.visit.status) {
      case VisitStatus.Accepted: this.backgroundColor = '#55ff55'; break;
      case VisitStatus.ChangeRequested: this.backgroundColor = '#5555ff'; break;
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

}
