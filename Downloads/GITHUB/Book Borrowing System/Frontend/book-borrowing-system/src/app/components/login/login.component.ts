import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
  ) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // Convenience getter for easy access to form fields
  get f(): { [key: string]: any } {
    return this.loginForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    // Stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }
    
      
      
      var username= this.loginForm.get('username')?.value;
      var password=this.loginForm.get('password')?.value;
    
    
  

    // Call your authentication service to login the user
    this.userService.authenticate(username,password)
      .subscribe(
        data => {
          alert('Login successful');
          // Navigate to the home page or another page after successful login
          localStorage.removeItem("data");
          localStorage.setItem("data",data.token);
          console.log(data.token);
          
          this.router.navigate(['dashboard']);
        },
        error => {
          console.error('Login failed:', error);
          alert("Invalid username and password")
        }
      );
  }
}
