import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7019/api/Users';

  constructor(private http: HttpClient,
    private jwtHelper: JwtHelperService = new JwtHelperService()
   ) { }

  // Fetch all users
  getUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  

authenticate(username: string, password: string): Observable<any> {
  return this.http.post<any>(`${this.apiUrl}/login`, { username, password });
}

isLoggedIn(): boolean {
  
  if(localStorage.getItem("data"))
  {
    return true;
  }
  else
  {
    return false;
  }
}
getDecodedToken(token: string | null): any | null {
  try {
    if (token === null) {
      console.error('Token is null.');
      return null;
    }

    const decodedToken = this.jwtHelper.decodeToken(token);

    if (decodedToken) {
      console.log('Decoded Token:', decodedToken);
      return decodedToken;
    } else {
      console.error('Token decoding failed.');
      return null;
    }
  } catch (error) {
    console.error('Error decoding token:', error);
    return null;
  }
}


  // Fetch a user by ID
  getUserById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  // Create a new user
  createUser(userDto: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, userDto);
  }
  

  // Update an existing user
  updateUser(id: string, userDto: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, userDto);
  }

  // Delete a user by ID
  deleteUser(id: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
  incrementUserTokens(userId: string): Observable<any> {
    const url = `${this.apiUrl}/update-tokens/${userId}/increment`;
    return this.http.put(url, {});
  }

  decrementUserTokens(userId: string): Observable<any> {
    const url = `${this.apiUrl}/update-tokens/${userId}/decrement`;
    return this.http.put(url, {});
  }
}