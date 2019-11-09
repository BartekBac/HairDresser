import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ClientService } from '../services/client.service';
import { Constants } from '../constants/Constants';
import * as jwt_decode from 'jwt-decode';
import { Client } from '../models/Client';

@Injectable({
  providedIn: 'root'
 })
export class ClientResolver implements Resolve<Client> {

  constructor(private clientService: ClientService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Client> {
    const token = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
    const decodedToken = jwt_decode(token);
    return this.clientService.getClient(decodedToken[Constants.DECODE_TOKEN_USER_ID]);
  }
}
