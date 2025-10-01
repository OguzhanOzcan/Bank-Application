import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'kredi-hesapla',loadChildren: () =>import('./features/credit-calculator/credit-calculator.module').then(m => m.CreditCalculatorModule), },
  { path: 'kredi-basvuru',loadChildren: () =>import('./features/credit-application/credit-application.module').then(m => m.CreditApplicationModule), },
  { path: 'bankalar',loadChildren: () => import('./features/banks/banks.module').then(m => m.BanksModule), },
  { path: 'musteri-ol', loadChildren: () => import('./features/musteri-ol/musteri-ol.module').then(m => m.MusteriOlModule) },
  { path: 'about', loadChildren: () => import('./features/about/about.module').then(m => m.AboutModule) },
  { path: 'contact', loadChildren: () => import('./features/contact/contact.module').then(m => m.ContactModule) },
  { path: 'login', loadChildren: () => import('./features/login/login.module').then(m => m.LoginModule) },
  { path: 'profil', loadChildren: () => import('./features/profil/profil.module').then(m => m.ProfilModule) },
  { path: 'my-credit', loadChildren: () => import('./features/my-credit/my-credit.module').then(m => m.MyCreditModule) },
  { path: 'forgot-password', loadChildren: () => import('./features/forgot-password/forgot-password.module').then(m => m.ForgotPasswordModule) },
  { path: '', redirectTo: 'kredi-hesapla', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
