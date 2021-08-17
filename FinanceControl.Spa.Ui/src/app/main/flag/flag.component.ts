import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlagService } from './flag.service';

@Component({
  selector: 'app-flag',
  templateUrl: './flag.component.html',
  styleUrls: ['./flag.component.scss']
})
export class FlagComponent implements OnInit {

  gridFlags: any;
  showGrid: boolean = false;

  constructor(private flagService: FlagService, private router: Router) { }

  ngOnInit(): void {
    this.flagService.get().subscribe(result => {
      this.gridFlags = result;
      this.showGrid = true;
    })

  }


  showEdit() {
    this.router.navigate(['/flag/edit']);
  }

}
