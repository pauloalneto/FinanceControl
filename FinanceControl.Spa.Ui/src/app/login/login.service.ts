import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ViewModel } from '../common/model/viewModel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  _form: FormGroup;

  constructor() {
    this.getForm();

  }

  initVm(): ViewModel<any> {
    return new ViewModel({
      form: this._form,
      model: {},
    });
  }

  public getForm() {
    this._form = new FormGroup({
      userName: new FormControl(),
      password: new FormControl()
    })
  }
}
