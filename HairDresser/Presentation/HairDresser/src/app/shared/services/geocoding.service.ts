import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Location } from '../models/Location';
import { Address } from '../models/Address';
import { map } from 'rxjs/internal/operators';

@Injectable({
  providedIn: 'root'
})
export class GeocodingService {

  /**
   * LocationIQ
   * email: lebolgrscnoaenyotf@awdrt.org
   * token: 22943fdb8b30e6
   *
   * my home
   * lat: 50.1399893 lon: 18.8703565626402
   */

  private readonly LOCATIONIQ_API_URL = 'https://eu1.locationiq.com/v1/';
  private readonly LOCATIONIQ_API_KEY = '22943fdb8b30e6';

  constructor(private http: HttpClient) { }

  search(searchString: string): Observable<Location[]> {
    return this.http.get<any>(
      this.LOCATIONIQ_API_URL + 'search.php?' +
      'key=' + this.LOCATIONIQ_API_KEY +
      '&q=' + searchString +
      '&format=json').pipe(
        map(res => {
          let locations: Location[] = [];
          res.forEach(location => locations.push({latitude: location.lat, longitude: location.lon}));
          return locations;
        })
      );
  }

  reverse(latitude: number, longitude: number): Observable<Address> {
    return this.http.get<any>(
      this.LOCATIONIQ_API_URL + 'reverse.php?' +
      'key=' + this.LOCATIONIQ_API_KEY +
      '&lat=' + latitude +
      '&lon=' + longitude +
      '&format=json').pipe(
        map(res => {
          const address: Address = {
            city: res.address.county,
            houseNumber: res.address.house_number,
            street: res.address.road,
            zipCode: res.address.postcode
          };
          return address;
        })
      );
  }
}
