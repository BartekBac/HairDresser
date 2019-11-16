import { Service } from 'src/app/shared/models/Service';

export class VisitCreation {
  clientId: string;
  workerId: string;
  serviceIds: string[];
  term: Date;
  totalTime: number;
  totalPrice: number;
}
