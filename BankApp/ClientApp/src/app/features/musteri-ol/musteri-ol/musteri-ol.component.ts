import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { RegisterRequest, RegisterResponse } from 'src/app/models';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { passwordValidator, passwordMatchValidator } from 'src/app/shared/validators/password.validator';

@Component({
  selector: 'app-musteri-ol',
  templateUrl: './musteri-ol.component.html',
  styleUrls: ['./musteri-ol.component.css']
})
export class MusteriOlComponent implements OnInit {
  sehir: string[] = ['Ankara', 'İstanbul', 'Bursa', 'İzmir', 'Eskişehir'];
  registerForm!: FormGroup;
  serverErrorMessage: string | null = null;
  isLoading = false;

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName:       new FormControl('', Validators.required),
      lastName:        new FormControl('', Validators.required),
      email:           new FormControl('', [Validators.required, Validators.email]),
      birthDate:       new FormControl('', Validators.required),
      gender:          new FormControl('male', Validators.required),
      password:        new FormControl('', [Validators.required, passwordValidator]),
      confirmPassword: new FormControl('', Validators.required),
      phone:           new FormControl('', [Validators.required, Validators.pattern('^[0-9]{11}$')]),
      city:            new FormControl('', Validators.required)
    }, {
      validators: passwordMatchValidator
    });
  }

  onSubmit(): void {
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }

    const { confirmPassword, ...formValues } = this.registerForm.value;
    const dto: RegisterRequest = formValues;

    this.serverErrorMessage = null;
    this.isLoading = true;

    this.authService.register(dto)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: (res: RegisterResponse) => {
          console.log('Kayıt başarılı:', res);
          localStorage.setItem('accessToken', res.AccessToken);
          localStorage.setItem('refreshToken', res.refreshToken);
          this.registerForm.reset();

          setTimeout(() => {
            alert('Kayıt başarılı! Lütfen giriş yapınız.');
            this.router.navigate(['/login']);
          }, 50);
        },
        error: err => {
          if (err.status === 409 && err.error?.message) {
            this.serverErrorMessage = err.error.message;
            this.registerForm.get('email')?.setErrors({ emailTaken: true });
          } else {
            this.serverErrorMessage = 'Beklenmeyen bir hata oluştu.';
          }
          console.error('Kayıt sırasında hata:', err);
        }
      });
  }
}
