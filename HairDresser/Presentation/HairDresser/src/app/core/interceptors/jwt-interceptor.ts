import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Constants } from '../../shared/constants/Constants';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        const authToken = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
        if (authToken) {
          let headers = request.headers;
          headers = headers.append('Authorization', `Bearer ${authToken}`);
          headers = headers.append('Accept', 'application/json');
          headers = headers.append('Content-Type', 'application/json');
          request = request.clone({headers});
        }
        return next.handle(request);
    }
}
