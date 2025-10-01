import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MusteriOlComponent } from './musteri-ol/musteri-ol.component';

const routes: Routes = [
  {path: '', component: MusteriOlComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MusteriOlRoutingModule { }
