import { Component, OnInit } from '@angular/core';
import { FlagService } from './flag.service';

@Component({
  selector: 'app-flag',
  templateUrl: './flag.component.html',
  styleUrls: ['./flag.component.scss']
})
export class FlagComponent implements OnInit {

  gridFlags: any;
  showGrid: boolean = false;

  constructor(private flagService: FlagService) { }

  ngOnInit(): void {
    this.flagService.get().subscribe(result => {
      this.gridFlags = result;
      console.log('Flag service result: ', result, this.gridFlags)
      this.showGrid = true;
    })
  }

}
