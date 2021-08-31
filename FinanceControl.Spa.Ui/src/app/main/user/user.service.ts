import { Injectable } from "@angular/core";
import { ApiService } from "../../common/service/api.service";


@Injectable()
export class UserService {
  constructor(private api: ApiService<any>) { }

  public get() {
    return this.api.setResource('user').get()
  }

  public getDataCustom(filters?: any) {
    return this.api.setResource('user').getDataCustom(filters);
  }
}
