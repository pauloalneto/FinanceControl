import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderCustomComponent } from './components/header-custom/header-custom.component';
import { NavbarComponent } from './components/navbar/navbar.component';



import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { BreadcrumpCustomComponent } from './components/breadcrump-custom/breadcrump-custom.component';



@NgModule({
  declarations: [
    HeaderCustomComponent,
    NavbarComponent,
    BreadcrumpCustomComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatSidenavModule,
    MatTableModule,
  ],
  exports: [
    HeaderCustomComponent,
    NavbarComponent,
    BreadcrumpCustomComponent
  ]
})
export class UtilsModule { }
