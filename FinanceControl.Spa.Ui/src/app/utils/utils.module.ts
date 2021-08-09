import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderCustomComponent } from './components/header-custom/header-custom.component';
import { NavbarComponent } from './components/navbar/navbar.component';



import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';



@NgModule({
  declarations: [
    HeaderCustomComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatTableModule,
  ],
  exports: [
    HeaderCustomComponent,
    NavbarComponent
  ]
})
export class UtilsModule { }
