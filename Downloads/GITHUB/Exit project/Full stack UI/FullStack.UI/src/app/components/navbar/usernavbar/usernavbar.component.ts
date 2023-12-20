import { Component,OnInit } from '@angular/core';

import { UserServiceService } from 'src/app/services/user-service.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/authentication.service';
@Component({
  selector: 'app-usernavbar',
  templateUrl: './usernavbar.component.html',
  styleUrls: ['./usernavbar.component.css']
})
export class UsernavbarComponent implements OnInit{
  
  
  name: any;
  userId: any;
  
  constructor(
    private userService: UserServiceService,
    private router:Router,
    private authservice:AuthService){

  }
  
  logout()
  {
    
    sessionStorage.clear();
    window.history.pushState({}, '', '/');
    // Navigate to the login page
    this.router.navigateByUrl('/Login');
    localStorage.removeItem('tokenUser');
    localStorage.removeItem('userType');
    // Remove the email ID from the local storage
    localStorage.removeItem('emailId');
    localStorage.removeItem('userId')

  // Redirect to login page or any other desired route
  
    
  }

  ngOnInit() {
    const email = localStorage.getItem('emailId');
    if (email) {
      this.getUserDetails(email);
    } else {
      // Handle the case when email is not found in local storage
      // For example, redirect the user to the login page
      this.router.navigate(['/login']);
    }
  }
  
  
  getUserDetails(email: string): void {
    this.userService.getUserByEmail(email).subscribe(
      (response) => {
        // Handle the response here
        const name = response.name;
      const userId = response.id;
      localStorage.setItem('userId', userId);
    
        
      this.name=name;
      this.userId=userId;
      },
      (error) => {
        // Handle the error here
        console.error(error);
      }
    );
  }
  
}

