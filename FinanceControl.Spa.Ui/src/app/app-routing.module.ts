import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlagComponent } from './main/flag/flag.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'flag', component: FlagComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
