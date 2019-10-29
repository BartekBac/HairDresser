import { Schedule } from 'src/app/shared/models/Schedule';
import { UserData } from 'src/app/shared/models/UserData';

export class WorkerCreation {
  firstName: string;
  lastName: string;
  salonId: string;
  schedule: Schedule;
  userData: UserData;
  imageData: string;
}
