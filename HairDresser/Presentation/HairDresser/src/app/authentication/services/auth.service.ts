import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginCredential } from '../models/LoginCredential';
import { LoginResponse } from '../models/LoginResponse';
import { tap, catchError } from 'rxjs/internal/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'https://localhost:44340/api/';

  constructor(
    private http: HttpClient
  ) { }

  login(loginCredential: LoginCredential) {
    return this.http.post<LoginResponse>(this.baseUrl + 'login', loginCredential)
      .pipe(
        tap(response => {
          localStorage.setItem('token', response.token);
          localStorage.setItem('user_id', response.id);
          console.log('navigate to ' + response.role);
          //const decodedToken = jwt_decode(response.auth_token);
          //this.router.navigate([decodedToken[EMPLOYEE_ROLE]]);
        }),
        catchError(error => {
          //this.spinnerService.hide();
          console.log(error);
          return throwError(error);
        })
      );
  }

}
