import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Constants } from '../../shared/constants/Constants';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        const auth_token = localStorage.getItem(Constants.LOCAL_STORAGE_AUTH_TOKEN);
        if (auth_token) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${auth_token}`
                }
            });
        }
        return next.handle(request);
    }
}
