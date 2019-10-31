import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { WorkerCreation } from 'src/app/salon/models/WorkerCreation';
import { UploadImage } from '../models/UploadImage';
import { UpdateSchedule } from '../models/UpdateSchedule';
import { UpdateUserData } from '../models/UpdateUserData';
import { Worker } from '../models/Worker';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {

  private baseUrl = Constants.SERVER_BASE_URL + 'worker/';

  constructor(private http: HttpClient) { }

  addWorker(worker: WorkerCreation) {
    return this.http.post(this.baseUrl, worker);
  }

  editWorker(worker: Worker) {
    return this.http.put(this.baseUrl + worker.id, worker);
  }

  uploadImage(workerId: string, uploadImage: UploadImage) {
    return this.http.put(this.baseUrl + workerId + '/update-image', uploadImage);
  }
}
