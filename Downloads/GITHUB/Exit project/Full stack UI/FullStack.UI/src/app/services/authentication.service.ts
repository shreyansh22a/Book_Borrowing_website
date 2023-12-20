import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Authentication } from '../Models/Users.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseApiUrl = "https://localhost:7100";
  
 
  constructor(private http: HttpClient,
    ) { }
  

    login(CheckLoginRequest: Authentication): Observable< any > {
      return this.http.post<any>(
        `${this.baseApiUrl}/api/User/login?email=${CheckLoginRequest.email}&password=${CheckLoginRequest.password}`,
        null
      );
    }
}

