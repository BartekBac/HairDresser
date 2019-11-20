import { Pipe, PipeTransform } from '@angular/core';
import { VisitStatus } from '../enums/VisitStatus';

@Pipe({
  name: 'visitStatus'
})
export class VisitStatusPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    switch (value) {
      case VisitStatus.Accepted: return 'accepted';
      case VisitStatus.ChangeRequested: return 'change requested';
      case VisitStatus.Pending: return 'pending';
      case VisitStatus.Rejected: return 'rejected';
      default: return '';
    }
  }

}
