import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyCreditComponent } from './my-credit/my-credit.component';

const routes: Routes = [
  { path: '', component: MyCreditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyCreditRoutingModule { }
