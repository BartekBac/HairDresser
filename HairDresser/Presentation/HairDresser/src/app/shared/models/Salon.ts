import { Address } from './Address';
import { Schedule } from './Schedule';
import { User } from './User';
import { Worker } from './Worker';
import { Service } from './Service';

export class Salon {
  id: string;
  name: string;
  address: Address;
  additionalInfo: string;
  type: number;
  schedule: Schedule;
  admin: User;
  imageSource: string;
  workers: Worker[];
  services: Service[];
}
