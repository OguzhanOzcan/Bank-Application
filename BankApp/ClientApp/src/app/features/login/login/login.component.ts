import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { LoginRequest, LoginResponse } from 'src/app/models';
import { AuthService } from 'src/app/core/services/auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthStatusService } from 'src/app/core/services/auth-status.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  isLoading = false;
  serverErrorMessage: string | null = null;

  constructor(
    private authService: AuthService,
    private router: Router,
    private authStatusService: AuthStatusService
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit(): void {
    this.serverErrorMessage = null;
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    const dto: LoginRequest = this.loginForm.value;
    this.isLoading = true;

    this.authService.login(dto)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: (res: LoginResponse) => {
          localStorage.setItem('accessToken', res.accessToken);
          localStorage.setItem('refreshToken', res.refreshToken);
          this.authStatusService.setLoggedIn(true);

          setTimeout(() => {
            alert('Giriş Başarılı!');
            this.router.navigate(['/kredi-basvuru']);
          }, 50);
        },
        error: err => {
          if (err.status === 401 && err.error?.message) {
            this.serverErrorMessage = err.error.message;
          } else {
            this.serverErrorMessage = 'Giriş başarısız. Lütfen tekrar deneyin.';
          }
          console.error('Login error:', err);
        }
      });
  }
}
