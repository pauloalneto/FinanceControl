import { Injectable } from '@angular/core';
import { ApiService } from '../../common/service/api.service';

@Injectable({
  providedIn: 'root'
})
export class FlagService {

  constructor(private api: ApiService<any>) { }

  public get() {
    return this.api.setResource('flag').get()
  }
}
