import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Salon } from '../models/Salon';
import { SalonService } from '../services/salon.service';

@Injectable({
  providedIn: 'root'
 })
export class ClientAddSalonResolver implements Resolve<Salon[]> {

  constructor(private salonService: SalonService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Salon[]> {
    return this.salonService.getSalons();
  }
}
