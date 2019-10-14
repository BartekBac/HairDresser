import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginCredential } from '../models/LoginCredential';
import { LoginResponse } from '../models/LoginResponse';
import { tap, catchError } from 'rxjs/internal/operators';
import { throwError } from 'rxjs';
import { Observable } from 'rxjs';
import * as jwt_decode from 'jwt-decode';
import { Constants } from '../../shared/constants/Constants';
import { Router } from '@angular/router';
import { Role } from 'src/app/shared/enums/Role';
import { RegisterClientCredentials } from '../models/RegisterClientCredentials';
import { RegisterSalonCredentials } from '../models/RegisterSalonCredentials';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = Constants.SERVER_BASE_URL + 'auth/';

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  login(loginCredential: LoginCredential) {
    return this.http.post<LoginResponse>(this.baseUrl + 'login', loginCredential)
    .pipe(
      tap(response => {
        localStorage.setItem(Constants.LOCAL_STORAGE_AUTH_TOKEN, response.token);
        const decodedToken = jwt_decode(response.token);
        this.router.navigate([decodedToken[Constants.DECODE_TOKEN_ROLE]]);
      }),
      catchError(error => {
        console.log(error);
        return throwError(error);
      })
    );
  }

  registerClient(registerCredentials: RegisterClientCredentials): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.baseUrl + 'register/client', registerCredentials)
    .pipe(
      tap(response => {
        console.log(response);
        this.router.navigate(['auth']);
      }),
      catchError(error => {
        console.log(error);
        return throwError(error);
      })
    );
  }

  registerSalon(registerCredentials: RegisterSalonCredentials): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.baseUrl + 'register/salon', registerCredentials)
    .pipe(
      tap(response => {
        console.log(response);
        this.router.navigate(['auth']);
      }),
      catchError(error => {
        console.log(error);
        return throwError(error);
      })
    );
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
  }

  isAuthorized(requiredRole: Role): boolean {

    const token = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);

    if (!token) {
      console.log('User not logged in.');
      return false;
    }

    const decodedToken = jwt_decode(token);

    if (!decodedToken) {
      console.log('Invalid token');
      return false;
    }

    return Role[requiredRole] === decodedToken[Constants.DECODE_TOKEN_ROLE];
  }

  logout() {
    localStorage.removeItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
    this.router.navigate(['/login']);
  }
}
