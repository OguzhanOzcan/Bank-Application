export interface RegisterRequest {
  firstName: string;
  lastName: string;
  email: string;
  birthDate: string;
  gender: 'male' | 'female';
  password: string;
  phone: string;
  city: string;
}

export interface RegisterResponse {
  userId: string;
  AccessToken: string;
  refreshToken: string;
}
