import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthGuard } from './auth-guard';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuard extends AuthGuard implements CanActivate {

  override canActivate(): boolean {
    const isUserLoggedIn = super.canActivate();
    const userType = localStorage.getItem('userType');

    if (isUserLoggedIn && userType === 'admin') {
      // User is authenticated as an admin, allow access to the route
      return true;
    } else {
      // User is not authenticated as an admin, redirect to login page
      this.router.navigate(['/login']);
      return false;
    }
  }
}
