import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderCustomComponent } from './components/header-custom/header-custom.component';
import { NavbarComponent } from './components/navbar/navbar.component';



@NgModule({
  declarations: [
    HeaderCustomComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    HeaderCustomComponent,
    NavbarComponent
  ]
})
export class UtilsModule { }
