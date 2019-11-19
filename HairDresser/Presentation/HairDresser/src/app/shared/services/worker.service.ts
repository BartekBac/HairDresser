import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { WorkerCreation } from 'src/app/salon/models/WorkerCreation';
import { UploadImage } from '../models/UploadImage';
import { Worker } from '../models/Worker';
import { Service } from '../models/Service';
import { Observable } from 'rxjs';
import { Visit } from '../models/Visit';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {

  private baseUrl = Constants.SERVER_BASE_URL + 'worker/';

  constructor(private http: HttpClient) { }

  addWorker(worker: WorkerCreation) {
    return this.http.post(this.baseUrl, worker);
  }

  getWorkerServices(workerId: string): Observable<Service[]> {
    return this.http.get<Service[]>(this.baseUrl + workerId + '/services');
  }

  getWorkerActiveVisits(workerId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(this.baseUrl + workerId + '/visits-active');
  }

  assignWorkerServices(workerId: string, services: Service[]) {
    return this.http.post(this.baseUrl + workerId + '/assign-services', {workerId: null, services: services});
  }

  editWorker(worker: Worker) {
    return this.http.put(this.baseUrl + worker.id, worker);
  }

  uploadImage(workerId: string, uploadImage: UploadImage) {
    return this.http.put(this.baseUrl + workerId + '/update-image', uploadImage);
  }

  deleteWorker(workerId: string) {
    return this.http.delete(this.baseUrl + workerId);
  }
}
