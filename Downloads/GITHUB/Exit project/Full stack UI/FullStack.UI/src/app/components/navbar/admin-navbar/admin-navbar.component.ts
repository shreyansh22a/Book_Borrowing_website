import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/authentication.service';
@Component({
  selector: 'app-admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.css']
})
export class AdminNavbarComponent {


  constructor(private router: Router,
    private authservice : AuthService) {}
  logout()
{
  localStorage.removeItem('tokenUser');
  localStorage.removeItem('userType');
  sessionStorage.clear();

  // Navigate to the login page
  window.history.pushState({}, '', '/');
  this.router.navigateByUrl('/Login');
  localStorage.removeItem('token');
  // Redirect to login page or any other desired route
  
  
}
}
