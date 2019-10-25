import { Injectable } from '@angular/core';
import { Constants } from '../constants/Constants';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SalonData } from '../models/SalonData';
import { delay } from 'rxjs/internal/operators';
import { UploadImage } from '../models/UploadImage';

@Injectable({
  providedIn: 'root'
})
export class SalonService {

  private baseUrl = Constants.SERVER_BASE_URL + 'salon/';

  constructor(private http: HttpClient) { }

  getSalon(id: string): Observable<SalonData> {
    return this.http.get<SalonData>(this.baseUrl + id).pipe(delay(1500));
  }

  uploadSalonImage(uploadImage: UploadImage) {
    return this.http.post(this.baseUrl + uploadImage.entityId + '/image', uploadImage);
  }
}
