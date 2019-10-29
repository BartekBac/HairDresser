import { Address } from './Address';
import { Schedule } from './Schedule';
import { User } from './User';

export class Salon {
  name: string;
  address: Address;
  additionalInfo: string;
  type: number;
  schedule: Schedule;
  admin: User;
  imageSource: string;
}
