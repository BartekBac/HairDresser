import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { SalonData } from '../models/SalonData';
import { SalonService } from '../services/salon.service';
import { Constants } from '../constants/Constants';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
 })
export class SalonResolver implements Resolve<SalonData> {

  constructor(private salonService: SalonService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<SalonData> {
    const token = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
    const decodedToken = jwt_decode(token);
    return this.salonService.getSalon(decodedToken[Constants.DECODE_TOKEN_USER_ID]);
  }
}
