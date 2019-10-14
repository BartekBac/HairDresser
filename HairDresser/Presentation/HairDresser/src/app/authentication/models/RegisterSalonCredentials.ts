import { UserData } from './UserData';
import { Address } from 'src/app/shared/models/Address';

export class RegisterSalonCredentials {
  name: string;
  additionalInfo: string;
  type: number;
  address: Address;
  userData: UserData;
}
