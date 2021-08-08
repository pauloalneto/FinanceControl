import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FlagComponent } from './flag.component';


@NgModule({
  imports: [
    RouterModule.forChild([
      { path: '', component: FlagComponent, data: { title: "Flag" } }
    ])
  ],
  exports: [RouterModule]
})
export class FlagRoutingModule { }
