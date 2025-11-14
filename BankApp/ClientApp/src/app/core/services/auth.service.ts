import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  RegisterRequest,
  RegisterResponse,
  LoginRequest,
  LoginResponse
} from 'src/app/models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = 'http://localhost:5000/api/auth';

  constructor(private http: HttpClient) { }

  register(data: RegisterRequest): Observable<RegisterResponse> {
    return this.http.post<RegisterResponse>(`${this.apiUrl}/register`, data);
  }

  login(data: LoginRequest): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, data);
  }

  sendResetCode(email: string): Observable<any> {
    console.log('Send reset code to:', email);
    return this.http.post(`${this.apiUrl}/send-reset-code`, { email });
  }

  verifyResetCode(email: string, code: string): Observable<any> {
    console.log('Verify code:', code, 'for email:', email);
    return this.http.post(`${this.apiUrl}/verify-reset-code`, { email, code });
  }

  resetPassword(email: string, newPassword: string): Observable<any> {
    console.log('Reset password for:', email, 'to:', newPassword);
    return this.http.put(`${this.apiUrl}/reset-password`, { email, newPassword });
  }
}
