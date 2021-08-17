import { ModuleWithProviders } from '@angular/compiler/src/core';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './main/dashboard/dashboard.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  {
    path: '', component: MainComponent, children: [
      { path: 'flag', loadChildren: () => import('./main/flag/flag.module').then(m => m.FlagModule) },
      { path: 'dashboard', component: DashboardComponent, data: { breadcrumb: 'Dashboard'} }
    ]
  },
  { path: '', redirectTo:'', pathMatch: 'full' }
  ];

export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(routes)
