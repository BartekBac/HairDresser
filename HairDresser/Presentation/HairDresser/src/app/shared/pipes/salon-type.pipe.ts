import { Pipe, PipeTransform } from '@angular/core';
import { SalonType } from '../enums/SalonType';

@Pipe({
  name: 'salonType'
})
export class SalonTypePipe implements PipeTransform {
  transform(value: any, args?: any): any {
    switch (value) {
      case SalonType.Unisex: return 'Female and male';
      case SalonType.Female: return 'Female';
      case SalonType.Male: return 'Male';
      default: return '';
    }
  }

}
