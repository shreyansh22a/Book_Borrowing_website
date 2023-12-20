import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
 // Update with your auth service

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor( private router: Router) {}
  

  canActivate(): boolean {
    var data=localStorage.getItem("data");
    if (data) {
      return true;
    } else {
      // Redirect to the login page if not authenticated
      this.router.navigate(['/login']);
      return false;
    }
  }
}
