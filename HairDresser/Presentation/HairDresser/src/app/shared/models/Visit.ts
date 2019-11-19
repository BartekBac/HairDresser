import { Service } from './Service';
import { Client } from './Client';
import { VisitStatus } from '../enums/VisitStatus';
import { Worker } from './Worker';

export class Visit {
  id: string;
  client: Client;
  worker: Worker;
  services: Service[];
  status: VisitStatus;
  term: Date;
  totalTime: number;
  totalPrice: number;
  info: string;
}
