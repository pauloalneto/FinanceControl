import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderCustomComponent } from './components/header-custom/header-custom.component';
import { NavbarComponent } from './components/navbar/navbar.component';



import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';
import { BreadcrumbCustomComponent } from './components/breadcrumb-custom/breadcrumb-custom.component';
import { LoadingComponent } from './components/loading/loading.component';
import { LoadingInterceptor } from './components/loading/loadingInterceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';



@NgModule({
  declarations: [
    HeaderCustomComponent,
    NavbarComponent,
    BreadcrumbCustomComponent,
    LoadingComponent
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
    BreadcrumbCustomComponent,
    LoadingComponent
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true }]
})
export class UtilsModule { }
