import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants/Constants';
import { ServiceCreation } from 'src/app/salon/models/ServiceCreation';
import { Service } from '../models/Service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  private baseUrl = Constants.SERVER_BASE_URL + 'service/';

  constructor(private http: HttpClient) { }

  addService(service: ServiceCreation) {
    return this.http.post(this.baseUrl, service);
  }

  editService(service: Service) {
    return this.http.put(this.baseUrl + service.id, service);
  }

  deleteService(serviceId: string) {
    return this.http.delete(this.baseUrl + serviceId);
  }

}
