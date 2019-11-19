import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { VisitCreation } from 'src/app/client/models/VisitCreation';

@Injectable({
  providedIn: 'root'
})
export class VisitService {

  private baseUrl = Constants.SERVER_BASE_URL + 'visit/';

  constructor(private http: HttpClient) { }

  addVisit(visit: VisitCreation) {
    return this.http.post(this.baseUrl, visit);
  }

}
