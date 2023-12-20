import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(public router: Router) {}

  canActivate(): boolean {
    const token = localStorage.getItem('tokenUser');
    const userType = localStorage.getItem('userType');

    if (token && userType === 'user') {
      // User is authenticated as a regular user, allow access to the route
      return true;
    } else if (token && userType === 'admin') {
      // User is authenticated as an admin, allow access to the route
      return true;
    } else {
      // User is not authenticated, redirect to login page
      this.router.navigate(['/login']);
      return false;
    }
  }
}
