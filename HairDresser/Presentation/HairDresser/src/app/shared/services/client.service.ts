import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../models/Client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private baseUrl = Constants.SERVER_BASE_URL + 'client/';

  constructor(private http: HttpClient) { }

  getClient(id: string): Observable<Client> {
    return this.http.get<Client>(this.baseUrl + id);
  }
}
