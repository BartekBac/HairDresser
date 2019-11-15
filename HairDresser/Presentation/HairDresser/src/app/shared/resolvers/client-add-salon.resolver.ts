import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Salon } from '../models/Salon';
import { SalonService } from '../services/salon.service';
import * as jwt_decode from 'jwt-decode';
import { Constants } from '../constants/Constants';

@Injectable({
  providedIn: 'root'
 })
export class ClientAddSalonResolver implements Resolve<Salon[]> {

  constructor(private salonService: SalonService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Salon[]> {
    const token = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
    const decodedToken = jwt_decode(token);
    return this.salonService.getAvaiableSalons(decodedToken[Constants.DECODE_TOKEN_USER_ID]);
  }
}
