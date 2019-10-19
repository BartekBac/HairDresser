import { UserData } from './UserData';
import { Address } from 'src/app/shared/models/Address';
import { Schedule } from 'src/app/shared/models/Schedule';

export class RegisterSalonCredentials {
  name: string;
  additionalInfo: string;
  type: number;
  address: Address;
  schedule: Schedule;
  userData: UserData;
}
