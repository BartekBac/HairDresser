import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SalonData } from '../models/SalonData';
import { delay } from 'rxjs/internal/operators';
import { UploadImage } from '../models/UploadImage';
import { UpdateUserData } from '../models/UpdateUserData';
import { UpdateSchedule } from '../models/UpdateSchedule';
import { Salon } from '../models/Salon';

@Injectable({
  providedIn: 'root'
})
export class SalonService {

  private baseUrl = Constants.SERVER_BASE_URL + 'salon/';

  constructor(private http: HttpClient) { }

  getSalons(): Observable<Salon[]> {
    return this.http.get<Salon[]>(this.baseUrl);
  }

  getSalon(id: string): Observable<Salon> {
    return this.http.get<Salon>(this.baseUrl + id).pipe(delay(1500));
  }


  uploadImage(salonId: string, uploadImage: UploadImage) {
    return this.http.post(this.baseUrl + salonId + '/update-image', uploadImage);
  }
  updateSalonData(salonId: string, salonData: SalonData) {
    return this.http.put(this.baseUrl + salonId + '/update-salon-data', salonData);
  }
  updateSchedule(salonId: string, schedule: UpdateSchedule) {
    return this.http.put(this.baseUrl + salonId + '/update-schedule', schedule);
  }
  updateUserData(salonId: string, userData: UpdateUserData) {
    return this.http.put(this.baseUrl + salonId + '/update-user-data', userData);
  }
}
