import { Address } from './Address';
import { Schedule } from './Schedule';
import { User } from './User';
import { Worker } from './Worker';
import { Service } from './Service';
import { Location } from './Location';

export class Salon {
  id: string;
  name: string;
  address: Address;
  location: Location;
  additionalInfo: string;
  type: number;
  rating: number;
  schedule: Schedule;
  admin: User;
  imageSource: string;
  workers: Worker[];
  services: Service[];
}
