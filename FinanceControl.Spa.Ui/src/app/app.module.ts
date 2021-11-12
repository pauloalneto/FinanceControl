import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';


import { RoutingDefault } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiService } from './common/service/api.service';
import { MainComponent } from './main/main.component';
import { UtilsModule } from './utils/utils.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import { DashboardComponent } from './main/dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RoutingDefault,
    BrowserAnimationsModule,
    MatSidenavModule,
    UtilsModule,
  ],
  providers: [
    HttpClientModule,
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
