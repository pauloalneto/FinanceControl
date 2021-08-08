import { ModuleWithProviders } from '@angular/compiler/src/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  {
    path: '', component: MainComponent, data: { title: "Main" }, children: [
      { path: 'flag', loadChildren: () => import('./main/flag/flag.module').then(m => m.FlagModule)}
    ]
  }
];

export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(routes)
