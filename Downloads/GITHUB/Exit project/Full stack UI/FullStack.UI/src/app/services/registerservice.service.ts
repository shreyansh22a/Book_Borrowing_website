import { Injectable } from '@angular/core';
import { Users } from '../Models/Users.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterserviceService {
  baseApiUrl = "https://localhost:7100";
  
  constructor(private http: HttpClient) { } // Inject HttpClient here

  addUser(addUserRequest: Users): Observable<Users> { // Update the return type to Observable<any>
    return this.http.post<Users>(this.baseApiUrl + '/api/User/register', addUserRequest);
  }
  getAllUsers(): Observable<Users[]>
  {
    return this.http.get<Users[]>(this.baseApiUrl + '/api/Product');

  }
  
  checkEmailExists(Email: string): Observable<boolean> {
    return this.http.get<boolean>(this.baseApiUrl + '/api/User/CheckEmailExists?email=' + Email);
  }
}
