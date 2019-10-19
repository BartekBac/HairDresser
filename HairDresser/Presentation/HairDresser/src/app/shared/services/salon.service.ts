import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Salon } from '../models/Salon';
import { delay } from 'rxjs/internal/operators';

@Injectable({
  providedIn: 'root'
})
export class SalonService {

  private baseUrl = Constants.SERVER_BASE_URL + 'salon/';

  constructor(private http: HttpClient) { }

  getSalon(id: string): Observable<Salon> {
    return this.http.get<Salon>(this.baseUrl + id).pipe(delay(1500));
  }
}
