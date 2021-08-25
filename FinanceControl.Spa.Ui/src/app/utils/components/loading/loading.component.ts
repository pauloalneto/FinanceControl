import { Component, Input, OnInit } from '@angular/core';
import { RouteConfigLoadEnd, RouteConfigLoadStart, Router, RouterEvent } from '@angular/router';
import { delay, filter } from 'rxjs/operators';
import { LoadingService } from './loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {

  loading: boolean = false;

  constructor(private loadingService: LoadingService) {


  }

  ngOnInit(): void {
    this.loadingService.loadingSubject.pipe(delay(0)).subscribe(loading => {
      this.loading = loading;
    })
  }

}
