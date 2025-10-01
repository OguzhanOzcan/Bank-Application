import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CreditApplicationRoutingModule } from './credit-application-routing.module';
import { CreditApplicationComponent } from './credit-application/credit-application.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [CreditApplicationComponent],
  imports: [
    FormsModule,
    CommonModule,
    SharedModule,
    HttpClientModule,
    CreditApplicationRoutingModule,
  ]
})
export class CreditApplicationModule { }
