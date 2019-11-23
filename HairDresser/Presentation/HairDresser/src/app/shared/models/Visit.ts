import { Service } from './Service';
import { Client } from './Client';
import { VisitStatus } from '../enums/VisitStatus';
import { Worker } from './Worker';

export class Visit {
  id: string;
  clientId: string;
  clientFirstName: string;
  clientLastName: string;
  clientUserName: string;
  clientEmail: string;
  clientPhoneNumber: string;
  workerId: string;
  workerFirstName: string;
  workerLastName: string;
  workerRating: number;
  workerUserName: string;
  workerEmail: string;
  workerPhoneNumber: string;
  services: Service[];
  status: VisitStatus;
  term: Date;
  totalTime: number;
  totalPrice: number;
  info: string;
  opinionSent: boolean;
}
