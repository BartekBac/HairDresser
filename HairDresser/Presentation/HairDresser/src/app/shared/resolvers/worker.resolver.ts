import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { WorkerService } from '../services/worker.service';
import { Constants } from '../constants/Constants';
import * as jwt_decode from 'jwt-decode';
import { Worker } from '../models/Worker';

@Injectable({
  providedIn: 'root'
 })
export class WorkerResolver implements Resolve<Worker> {

  constructor(private workerService: WorkerService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Worker> {
    const token = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
    const decodedToken = jwt_decode(token);
    return this.workerService.getWorker(decodedToken[Constants.DECODE_TOKEN_USER_ID]);
  }
}
