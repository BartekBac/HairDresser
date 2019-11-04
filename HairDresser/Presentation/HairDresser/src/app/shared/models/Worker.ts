import { Schedule } from './Schedule';
import { Service } from './Service';

export class Worker {
  id: string;
  firstName: string;
  lastName: string;
  rating: number;
  schedule: Schedule;
  services: Service[];
  userPhoneNumber: string;
  userEmail: string;
  userName: string;
  imageSource: string;
}
