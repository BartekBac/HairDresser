import { Schedule } from './Schedule';
import { Service } from './Service';
import { Opinion } from './Opinion';
import { Visit } from './Visit';

export class Worker {
  id: string;
  firstName: string;
  lastName: string;
  rating: number;
  schedule: Schedule;
  services: Service[];
  visits: Visit[];
  opinions: Opinion[];
  userPhoneNumber: string;
  userEmail: string;
  userName: string;
  imageSource: string;
}
