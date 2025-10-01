import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BanksRoutingModule } from './banks-routing.module';
import { BankComponent } from './banks/banks.component';


@NgModule({
  declarations: [BankComponent],
  imports: [
    CommonModule,
    BanksRoutingModule
  ]
})
export class BanksModule { }
