import { AbstractControl } from '@angular/forms';

export function passwordValidator(control: AbstractControl) {
  const value = control.value as string;
  if (!value) return null;
  const errors: any = {};
  if (value.length < 6) errors.minLength = true;
  if (!/[0-9]/.test(value)) errors.missingNumber = true;
  if (!/[a-zA-Z]/.test(value)) errors.missingLetter = true;
  if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) errors.missingSpecialChar = true;
  return Object.keys(errors).length ? errors : null;
}

export function passwordMatchValidator(form: AbstractControl) {
  const pwd = form.get('password')?.value;
  const cpw = form.get('confirmPassword')?.value;
  if (pwd !== cpw) {
    form.get('confirmPassword')?.setErrors({ passwordMismatch: true });
  } else {
    form.get('confirmPassword')?.setErrors(null);
  }
  return null;
}
