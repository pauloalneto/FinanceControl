import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderCustomComponent } from './components/header-custom/header-custom.component';
import { NavbarComponent } from './components/navbar/navbar.component';



import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HeaderCustomComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatSidenavModule,
    MatTableModule,
  ],
  exports: [
    HeaderCustomComponent,
    NavbarComponent
  ]
})
export class UtilsModule { }
