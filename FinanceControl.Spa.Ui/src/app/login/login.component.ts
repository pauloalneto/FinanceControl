import { Component, OnInit } from '@angular/core';
import { ViewModel } from '../common/model/viewModel';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  vm: ViewModel<any>;

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {
    this.vm = this.loginService.initVm();
    console.log(this.vm)
  }

}
