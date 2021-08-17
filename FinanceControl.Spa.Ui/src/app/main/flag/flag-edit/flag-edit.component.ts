import { Component, OnInit } from '@angular/core';
import { FlagService } from '.././flag.service';

export interface IBreadCrumb {
  label: string;
  url: string;
}

@Component({
  selector: 'app-flag-edit',
  templateUrl: './flag-edit.component.html',
  styleUrls: ['./flag-edit.component.scss']
})
export class FlagEditComponent implements OnInit {



  constructor(private flagService: FlagService) { }



  ngOnInit(): void {

  }

}
