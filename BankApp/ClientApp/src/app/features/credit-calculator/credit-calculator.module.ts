import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';
import { CreditCalculatorRoutingModule } from './credit-calculator-routing.module';
import { CreditCalculatorComponent } from './credit-calculator/credit-calculator.component';


@NgModule({
  declarations: [CreditCalculatorComponent],
  imports: [
    FormsModule,
    SharedModule,
    CommonModule,
    HttpClientModule,
    CreditCalculatorRoutingModule
  ]
})
export class CreditCalculatorModule { }


