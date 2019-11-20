import { Pipe, PipeTransform } from '@angular/core';
import { VisitStatus } from '../enums/VisitStatus';

@Pipe({
  name: 'visitStatusIcon'
})
export class VisitStatusIconPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    switch (value) {
      case VisitStatus.Accepted: return 'pi pi-check-circle';
      case VisitStatus.ChangeRequested: return 'pi pi-question-circle';
      case VisitStatus.Pending: return 'pi pi-clock';
      case VisitStatus.Rejected: return 'pi pi-times-circle';
      default: return '';
    }
  }

}
