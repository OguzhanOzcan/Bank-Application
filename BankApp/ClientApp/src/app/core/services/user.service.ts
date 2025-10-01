import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface UserProfile {
  city: string;
  phone: string;
  email: string;
  lastName: string;
  firstName: string;
  birthDate: string;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:5000/api/customer';

  constructor(private http: HttpClient) { }

  getProfile(): Observable<UserProfile> {
    return this.http.get<UserProfile>(`${this.apiUrl}/me`);
  }

  updateProfile(data: Partial<UserProfile>): Observable<any> {
    return this.http.put(`${this.apiUrl}/update`, data);
  }

  updatePassword(payload: { password: string }): Observable<any> {
    return this.http.put(`${this.apiUrl}/update-password`, payload);
  }
}
