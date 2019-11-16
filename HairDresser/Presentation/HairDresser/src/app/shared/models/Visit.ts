import { Service } from './Service';
import { Worker } from 'cluster';
import { Client } from './Client';
import { VisitStatus } from '../enums/VisitStatus';

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
