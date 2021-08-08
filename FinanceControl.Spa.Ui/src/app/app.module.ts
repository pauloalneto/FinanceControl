import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';


import { RoutingDefault } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiService } from './common/service/api.service';
import { FlagModule } from './main/flag/flag.module';
import { MainComponent } from './main/main.component';
import { UtilsModule } from './utils/utils.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RoutingDefault,
    UtilsModule,
    BrowserAnimationsModule,
  ],
  providers: [
    HttpClientModule,
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
