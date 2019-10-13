import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const requiredRole = next.data.role;
      const isAuthorized = this.authService.isAuthorized(requiredRole);

      if (!isAuthorized) {
        const isAuthenticated = this.authService.isAuthenticated();
        if (isAuthenticated) {
          this.authService.logout();
        }
        this.router.navigate(['/auth']);
      }

      return isAuthorized;
  }

}
