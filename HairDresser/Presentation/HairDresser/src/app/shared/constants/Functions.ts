import { Time } from '../models/Time';
import { Day } from '../models/Day';
import { VisitStatus } from '../enums/VisitStatus';
import { Visit } from '../models/Visit';

export class Functions {
  public static copyObject(obj: any): any {
    return JSON.parse(JSON.stringify(obj));
  }
  public static compareTime(a: Time, b: Time, compareFlag = 'less'): Time {
    if (compareFlag === 'less') {
      if ((a.hour < b.hour) || ((a.hour === b.hour) && (a.minute < b.minute))) {
        return this.copyObject(a);
      } else {
        return this.copyObject(b);
      }
    } else if (compareFlag === 'greater') {
      if ((a.hour > b.hour) || ((a.hour === b.hour) && (a.minute > b.minute))) {
        return this.copyObject(a);
      } else {
        return this.copyObject(b);
      }
    }
  }

  public static dayToString(day: Day, beginEndFlag = 'begin'): string {
    if (day.isActive) {
      if (beginEndFlag === 'begin') {
        return this.timeToString(day.begin);
      } else {
        return this.timeToString(day.end);
      }
    } else {
      return '24:00';
    }
  }

  public static timeToString(time: Time): string {
    return time.hour.toString() + ':' + time.minute.toString().padStart(2, '0');
  }

  public static getVisitBackgroundColor(visit: Visit) {
    const date = new Date(visit.term);
    const now = new Date();
    if (date < now) {
      return '#555555';
    }

    switch (visit.status) {
      case VisitStatus.Accepted: return '#55ff55';
      case VisitStatus.ClientChangeRequested: return '#8888ff';
      case VisitStatus.WorkerChangeRequested: return '#3333ff';
      case VisitStatus.Pending: return '#ffff55';
      case VisitStatus.Rejected: return '#ff5555';
      default: return '#555555';
    }
  }

  public static getVisitTextColor(visit: Visit) {
    const date = new Date(visit.term);
    const now = new Date();
    if (date < now)  {
      return '#dedede';
    } else {
      return '#212121';
    }
  }
}
