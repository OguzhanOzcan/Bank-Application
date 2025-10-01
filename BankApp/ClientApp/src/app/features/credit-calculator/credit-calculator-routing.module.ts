import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreditCalculatorComponent } from './credit-calculator/credit-calculator.component';

const routes: Routes = [
  {path: '', component: CreditCalculatorComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreditCalculatorRoutingModule { }
