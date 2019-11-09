import { Salon } from './Salon';
import { Visit } from './Visit';
import { Opinion } from './Opinion';

export class Client {
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  userEmail: string;
  userPhone: string;
  imageSource: string;
  favoriteSalons: Salon[];
  visits: Visit[];
  sendOpinions: Opinion[];
}
