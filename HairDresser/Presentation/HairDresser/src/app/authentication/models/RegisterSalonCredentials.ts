import { UserData } from '../../shared/models/UserData';
import { Address } from 'src/app/shared/models/Address';
import { Schedule } from 'src/app/shared/models/Schedule';
import { Location } from 'src/app/shared/models/Location';

export class RegisterSalonCredentials {
  name: string;
  additionalInfo: string;
  type: number;
  address: Address;
  location: Location;
  schedule: Schedule;
  userData: UserData;
  imageData: string;
}
