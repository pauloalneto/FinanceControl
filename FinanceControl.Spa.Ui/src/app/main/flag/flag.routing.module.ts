import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FlagEditComponent } from './flag-edit/flag-edit.component';
import { FlagComponent } from './flag.component';


@NgModule({
  imports: [
    RouterModule.forChild([
      { path: '', component: FlagComponent, data: { breadcrump: 'Flag', title: "Flag" } },
      { path: 'edit', component: FlagEditComponent, data: { breadcrump: 'Edit', title: "Flag" } }
    ])
  ],
  exports: [RouterModule]
})
export class FlagRoutingModule { }
