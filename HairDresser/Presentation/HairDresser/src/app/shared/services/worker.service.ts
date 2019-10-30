import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { WorkerCreation } from 'src/app/salon/models/WorkerCreation';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {

  private baseUrl = Constants.SERVER_BASE_URL + 'worker/';

  constructor(private http: HttpClient) { }

  addWorker(worker: WorkerCreation) {
    return this.http.post(this.baseUrl, worker);
  }
}
