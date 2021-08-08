import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlagComponent } from './flag.component';
import { FlagService } from './flag.service';
import { ApiService } from '../../common/service/api.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonSharedModule } from '../../common/common-shared.module';
import { UtilsModule } from '../../utils/utils.module';
import { FlagRoutingModule } from './flag.routing.module';



@NgModule({
  declarations: [FlagComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CommonSharedModule,
    FlagRoutingModule,
    UtilsModule
  ],
  providers: [FlagService, ApiService]
})
export class FlagModule { }
