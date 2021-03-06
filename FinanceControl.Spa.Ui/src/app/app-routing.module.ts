import { ModuleWithProviders } from '@angular/compiler/src/core';
import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './main/dashboard/dashboard.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [

  { path: 'login', component: LoginComponent },
  {
    path: '', component: MainComponent, children: [
      { path: 'dashboard', component: DashboardComponent, data: { breadcrumb: 'Dashboard'} },
      { path: 'flag', loadChildren: () => import('./main/flag/flag.module').then(m => m.FlagModule) },
      { path: 'user', loadChildren: () => import('./main/user/user.module').then(m => m.UserModule) },
    ]}
  ];

export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(routes)
