import { FormGroup } from "@angular/forms";

export class ViewModel<T>{

  constructor(init: any = null) {
    this.form = init.form;
    this.model = init.model;
  }

  form: FormGroup;
  model: T;
}
