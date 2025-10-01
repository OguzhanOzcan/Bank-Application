import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyCreditComponent } from './my-credit/my-credit.component';
import { MyCreditRoutingModule } from './my-credit-routing.module';

@NgModule({
  declarations: [MyCreditComponent],
  imports: [
    CommonModule,
    MyCreditRoutingModule
  ]
})
export class MyCreditModule { }
