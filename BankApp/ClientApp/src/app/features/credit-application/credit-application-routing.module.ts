import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreditApplicationComponent } from './credit-application/credit-application.component';

const routes: Routes = [
  {path: '', component: CreditApplicationComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreditApplicationRoutingModule { }
