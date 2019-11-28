import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'rating'
})
export class RatingPipe implements PipeTransform {
  transform(value: any, args?: any): any {
    if (value === -1) {
      return '(no opinions)';
    } else {
      const numVal = +value;
      return numVal.toPrecision(3).toString();
    }
  }

}
