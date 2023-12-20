// login.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/services/authentication.service';
import { Authentication } from 'src/app/Models/Users.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  CheckLoginRequest: Authentication = {
    email: '',
    password: '',
  };

  showSuccessAlert: boolean = false;
  showFailureAlert: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar,
    private check: AuthService,
    private router: Router
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      registrationType: [false]
    });
  }

  login() {
    if (this.loginForm.invalid) {
      this.openSnackBar('Please fill in all the required fields.', 'Error');
      return;
    }

    this.CheckLoginRequest.email = this.loginForm.value.email;
    const emailtoshare = this.loginForm.value.email;
    this.CheckLoginRequest.password = this.loginForm.value.password;

    this.check.login(this.CheckLoginRequest).subscribe(
      (response: { accessToken: string; registrationType: string }) => {
        const registrationType = response.registrationType;
        console.log(response);

        if (registrationType === 'normal') {

        this.router.navigate(['/User-view']);
        this.openSnackBar('Login successful.', 'Success');
        localStorage.setItem('emailId', emailtoshare);
        localStorage.setItem('userType', 'user'); // Set the user type as 'user'
        
      } else if (registrationType === 'admin') {

        this.router.navigate(['/Admin-view']);
        this.openSnackBar('Login successful.', 'Success');
        localStorage.setItem('userType', 'admin'); // Set the user type as 'admin'

      } else {
        this.showFailureAlert = true;

        setTimeout(() => {
          this.showFailureAlert = false;
        }, 3000);
      }

      const accessToken = response.accessToken;
      localStorage.setItem('tokenUser', accessToken); //saving token to local storage


        // After a certain duration or event, hide the failure alert
        setTimeout(() => {
          this.showSuccessAlert = false;
        }, 3000);
      },
      (error: any) => {
        this.showFailureAlert = true;

        // After a certain duration or event, hide the failure alert
        setTimeout(() => {
          this.showFailureAlert = false;
        }, 3000);
      }
    );
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000 // Adjust the duration as per your preference
    });
  }
}
