import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  gridUsers: any;
  showGrid: boolean = false;

  constructor(private userService: UserService) { }

  ngOnInit(): void {

    this.userService.get().subscribe(result => {
      this.gridUsers = result;
      this.showGrid = true;
    })

  }

}
