import { Time } from '../models/Time';
import { Day } from '../models/Day';

export class Functions {
  public static copyObject(obj: any): any {
    return JSON.parse(JSON.stringify(obj));
  }
  public static compareTime(a: Time, b: Time, compareFlag = 'less'): Time {
    if (compareFlag === 'less') {
      if ((a.hour < b.hour) || ((a.hour === b.hour) && (a.minute < b.minute))) {
        return a;
      } else {
        return b;
      }
    } else if (compareFlag === 'greater') {
      if ((a.hour > b.hour) || ((a.hour === b.hour) && (a.minute > b.minute))) {
        return a;
      } else {
        return b;
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
}
