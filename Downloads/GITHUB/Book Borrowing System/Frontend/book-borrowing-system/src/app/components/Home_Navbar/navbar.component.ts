import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

constructor( private route: Router) {}

redirectToRegister() {
  this.route.navigate(["register"]);
}
redirectToLogin() {
  this.route.navigate(["login"]);
}
}