import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { Subscription, interval } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthStatusService } from 'src/app/core/services/auth-status.service';
import { passwordValidator, passwordMatchValidator } from 'src/app/shared/validators/password.validator';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit, OnDestroy {

  step: 'email' | 'code' | 'reset' = 'email';
  emailForm!: FormGroup;
  codeForm!: FormGroup;
  resetPasswordForm!: FormGroup;

  countdown: number = 100;
  private timerSub!: Subscription;

  isLoading = false;
  serverErrorMessage: string | null = null;

  constructor(
    private authService: AuthService,
    private authStatusService: AuthStatusService,
    private router: Router
  ) {}

  ngOnInit(): void {
    localStorage.removeItem('accessToken');
    this.authStatusService.setLoggedIn(false);

    this.emailForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email])
    });

    this.codeForm = new FormGroup({
      code: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{6}$')])
    });

    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', [Validators.required, passwordValidator]),
      confirmPassword: new FormControl('', Validators.required)
    }, { validators: passwordMatchValidator });
  }

  sendEmail(): void {
    if (this.emailForm.invalid) {
      this.emailForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;
    this.serverErrorMessage = null;

    const email = this.emailForm.value.email;
    this.authService.sendResetCode(email)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: () => {
          this.step = 'code';
          this.startCountdown();
        },
        error: err => {
          this.serverErrorMessage = err?.error?.message || 'Mail gönderilirken hata oluştu.';
          console.error(err);
        }
      });
  }

  verifyCode(): void {
    if (this.codeForm.invalid) {
      this.codeForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;
    this.serverErrorMessage = null;

    const code = this.codeForm.value.code;
    this.authService.verifyResetCode(this.emailForm.value.email, code)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: () => {
          this.step = 'reset';
          this.stopCountdown();
        },
        error: err => {
          if (err.error?.message) {
            this.serverErrorMessage = err.error.message;
          } else if (err.message) {
            this.serverErrorMessage = err.message;
          } else {
            this.serverErrorMessage = 'Kod doğrulama başarısız.';
          }
          console.error(err);
        }
      });
  }

  resetPassword(): void {
    if (this.resetPasswordForm.invalid) {
      this.resetPasswordForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;
    this.serverErrorMessage = null;

    const newPassword = this.resetPasswordForm.value.password;
    this.authService.resetPassword(this.emailForm.value.email, newPassword)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: () => {
          alert('Şifre başarıyla güncellendi! Lütfen giriş yapın.');
          this.resetForms();
          this.router.navigate(['/login']);
        },
        error: err => {
          this.serverErrorMessage = err?.error?.message || 'Şifre güncellenirken hata oluştu.';
          console.error(err);
        }
      });
  }

  startCountdown(): void {
    this.countdown = 100;
    this.timerSub = interval(1000).subscribe(() => {
      this.countdown--;
      if (this.countdown <= 0) {
        this.stopCountdown();
        this.serverErrorMessage = 'Kod süresi doldu. Lütfen tekrar deneyin.';
        this.step = 'email';
      }
    });
  }

  stopCountdown(): void {
    if (this.timerSub) {
      this.timerSub.unsubscribe();
    }
  }

  resetForms(): void {
    this.step = 'email';
    this.emailForm.reset();
    this.codeForm.reset();
    this.resetPasswordForm.reset();
  }

  ngOnDestroy(): void {
    this.stopCountdown();
  }

}
