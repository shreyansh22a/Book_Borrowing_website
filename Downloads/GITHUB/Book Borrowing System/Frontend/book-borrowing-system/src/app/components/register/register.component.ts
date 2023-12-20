import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
  ) {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      username: ['', Validators.required],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.pattern(/^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+])[a-zA-Z0-9!@#$%^&*()_+]+$/)
        ]
      ],
      confirmPassword: ['', [Validators.required, this.passwordMatchValidator]]
    });
  }
  private passwordMatchValidator(control: AbstractControl) {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    return password === confirmPassword ? null : { 'passwordMismatch': true };
  }


  get f() { return this.registerForm.controls; }

  isFieldInvalid(field: string) {
    return (
      this.registerForm.get(field)?.invalid &&
      (this.registerForm.get(field)?.touched || this.registerForm.get(field)?.dirty)
    );
  }

  // Helper method to mark all form controls as touched
  private markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();

      if (control instanceof FormGroup) {
        this.markFormGroupTouched(control);
      }
    });
  }

  onSubmit() {
    this.submitted = true;

    // Stop here if form is invalid
    if (this.registerForm.invalid) {
      alert("Fill all the fields properly")
      this.markFormGroupTouched(this.registerForm);
      return;
    }

    // Call your authentication service to register the user
    const userDto = {
      
        name: this.registerForm.get('name')?.value,
        username: this.registerForm.get('username')?.value,
        password: this.registerForm.get('password')?.value,
      
      
    };

    this.userService.createUser(userDto)
      .subscribe(
        data => {
          alert('Registration successful!!! please login');

          this.router.navigate(['/login']); // Navigate to login page after successful registration
        },
        error => {
          console.error('Registration failed:', error);
          alert('Registration failed Username already exist')
        }
      );
  }
}
