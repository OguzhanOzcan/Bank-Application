import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { passwordValidator, passwordMatchValidator } from 'src/app/shared/validators/password.validator';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {
  personalForm!: FormGroup;
  passwordForm!: FormGroup;
  activeTab: string = 'personal';
  sehir: string[] = ['Ankara', 'İstanbul', 'Bursa', 'İzmir', 'Eskişehir'];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.personalForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      birthDate: new FormControl({ value: '', disabled: true }),
      phone: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10,11}$')]),
      city: new FormControl('', Validators.required)
    });

    this.passwordForm = new FormGroup({
      password: new FormControl('', [Validators.required, passwordValidator]),
      confirmPassword: new FormControl('', Validators.required)
    }, { validators: passwordMatchValidator });

    this.loadUserData();
  }

  loadUserData(): void {
    this.userService.getProfile().subscribe(user => {
      this.personalForm.patchValue({
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email,
        birthDate: user.birthDate,
        phone: user.phone,
        city: user.city
      });
    });
  }

  updatePersonal(): void {
    if (this.personalForm.invalid) {
      this.personalForm.markAllAsTouched();
      return;
    }
    const updatedData = this.personalForm.value;
    this.userService.updateProfile(updatedData).subscribe({
      next: res => alert('Bilgiler başarıyla güncellendi!'),
      error: err => console.error('Güncelleme hatası:', err)
    });
  }

  updatePassword(): void {
    if (this.passwordForm.invalid) {
      this.passwordForm.markAllAsTouched();
      return;
    }
    const newPassword = this.passwordForm.value.password;
    this.userService.updatePassword({ password: newPassword }).subscribe({
      next: res => {
        alert('Şifre başarıyla güncellendi!'),
        this.passwordForm.reset();
      },
      error: err => console.error('Şifre güncelleme hatası:', err)
    });
  }

  switchTab(tab: string) {
    this.activeTab = tab;
  }
}
